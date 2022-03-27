import React, { Component } from 'react';

export class BusTrip extends Component {

    constructor(props) {
        super(props);
        this.state = { shortTrip: "", cheapTrip: "", loading: false };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.fileInput = React.createRef();
        this.timeStart = React.createRef();
        this.busStopStart = React.createRef();
        this.busStopEnd = React.createRef();
    }

    render() {
        return (
            <div>
                <h1 id="tabelLabel" >Быстрые и дешевые поездки</h1>
                <form onSubmit={this.handleSubmit}>
                    Файл с расписанием:
                    <input type="file" ref={this.fileInput} />
                    <br/>
                    Время начала:
                    <input type="text" ref={this.timeStart} defaultValue="00:00" />
                    <br />
                    Начальная остановка:
                    <input type="text" ref={this.busStopStart} defaultValue="1" />
                    Конечная остановка:
                    <input type="text" ref={this.busStopEnd} defaultValue="2" />
                    <br />
                    <input type="submit" value="Рассчитать" />
                </form>
                <p>Самый быстрый маршрут:</p>
                {this.state.loading ? "Загрузка ..." : this.state.shortTrip}
                <p>Самый дешевый маршрут:</p>
                {this.state.loading ? "Загрузка ..." :this.state.cheapTrip}
            </div>
        );
    }

    handleSubmit(event) {
        event.preventDefault();
        const selectedFile = this.fileInput.current.files[0];
        const startTime = this.timeStart.current.value;
        const busStopStart = this.busStopStart.current.value;
        const busStopEnd = this.busStopEnd.current.value;
        var fr = new FileReader();
        fr.onload = (async function () {
            event.preventDefault();
            const response = await fetch('bustrip/Post', {
                method: 'POST',
                headers:
                {
                    'Accept': 'application/json; charset=utf-8',
                    'Content-Type': 'application/json;charset=utf-8',
                },
                body: JSON.stringify({ FileData: fr.result, StartTime: startTime, BusStopStart: busStopStart, BusStopEnd: busStopEnd }),
            });
            const data_response = await response.json();
            if (data_response.exception != undefined) {
                this.setState({ exception: data_response.exception });
            }
            else {
                this.setState({ shortTrip: data_response.shortTrip, cheapTrip: data_response.cheapTrip, loading: false });
            }
        }
        ).bind(this);
        fr.readAsText(selectedFile);
        this.setState({ loading: true });
    }
}