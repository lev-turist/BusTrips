namespace BusTrips.Models
{
    public class PassengerStateWithHistory
    {
    }

    /* public class Passenger : IPassenger
  {
      public List<IPassengerState> States { get; set; }

      public void MinuteTick(Dictionary<int, BusPath> paths)
      {
          List<IPassengerState> newStates = new List<IPassengerState>();
          foreach (var state in States)
          {
              newStates.AddRange(state.MinuteTick(this, paths));
          }
          States = newStates;
      }
  }

  public class PassengerMove: IPassengerState
  {
      public Int32 BusStop
      {
          get
          {
              return FromStopNumber;
          }
      }

      public Boolean IsOnBusStop { get; }
      public Int32 BusNumber { get; }
      public Int32 TotalMinutes 
      { 
          get 
          {
              return minutesInState + (PrevPassengerState == null ? 0 : PrevPassengerState.TotalMinutes);
          }
      }
      public List<IPassengerState> PassengerStates { get; set; }
      public IPassengerState? PrevPassengerState { get; set; }

      public int minutesInState;
      public int MinutesToNextStop;
      public int busNumber;
      public int FromStopNumber { get; set; }
      public int ToStopNumber { get; set; }
      public List<IPassengerState> MinuteTick(IPassenger passenger, Dictionary<int, BusPath> paths)
      {
          ++minutesInState;
          --MinutesToNextStop;
          List<IPassengerState> newStates = new List<IPassengerState>();
          if (MinutesToNextStop > 0)
          {
              newStates.Add(this);
          }
          else
          {
              newStates.Add(new PassengerWaitBus()
              {
                  busStopNumber = ToStopNumber,
                  minutesInState = 0,
                  PrevPassengerState = this
              });

              if (paths.Values.Any(w => w.FromStopNumber == ToStopNumber && w.IsStandOnBusStop))
              {
                  foreach (var path in paths.Values.Where(w => w.FromStopNumber == ToStopNumber && w.IsStandOnBusStop))
                  {
                      newStates.Add(new PassengerMove()
                      {
                          busNumber = path.BusNumber,
                          FromStopNumber = ToStopNumber,
                          ToStopNumber = path.ToStopNumber,
                          minutesInState = 0,
                          MinutesToNextStop = path.MinutesToNextStop,
                          PrevPassengerState = this
                      });
                  }

                  PassengerStates = newStates;
              }
          }
          return newStates;
      }
  }

  public class PassengerWaitBus : IPassengerState
  {
      public Int32 BusStop
      {
          get
          {
              return busStopNumber;
          }
      }

      public Boolean IsOnBusStop { get; }
      public Int32 BusNumber { get; }
      public Int32 TotalMinutes
      {
          get
          {
              return minutesInState + (PrevPassengerState == null ? 0 : PrevPassengerState.TotalMinutes);
          }
      }
      public List<IPassengerState> PassengerStates { get; set; }
      public IPassengerState? PrevPassengerState { get; set; }

      public int busStopNumber;
      public int minutesInState;
      public List<IPassengerState> MinuteTick(IPassenger passenger, Dictionary<int, BusPath> paths)
      {
          ++minutesInState;

          List<IPassengerState> newStates = new List<IPassengerState>();
          if (paths.Values.Any(w => w.FromStopNumber == busStopNumber && w.IsStandOnBusStop))
          {
              foreach (var path in paths.Values.Where(w => w.FromStopNumber == busStopNumber && w.IsStandOnBusStop))
              {
                  newStates.Add(new PassengerMove()
                  {
                      busNumber = path.BusNumber,
                      FromStopNumber = busStopNumber,
                      ToStopNumber = path.ToStopNumber,
                      minutesInState = 0,
                      MinutesToNextStop = path.MinutesToNextStop,
                      PrevPassengerState = this
                  });
              }
              newStates.Add(new PassengerWaitBus()
              {
                  PrevPassengerState = this,
                  busStopNumber = busStopNumber,
                  minutesInState = 0
              });
              PassengerStates = newStates;
          }
          else
          {
              newStates.Add(this);
          }
          return newStates;
      }
  }
 */
}
