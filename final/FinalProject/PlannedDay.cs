public class PlannedDay : ISerializable
{
  private DateTime _date;
  private Meal _plannedMeal;
  private bool _isCompleted;
  private bool _isSkipped;


  public static PlannedDay Create(Meal meal)
  {
    PlannedDay plannedDay = new PlannedDay();
    DateTime today = new DateTime();

    plannedDay._date = today.Date;
    plannedDay._plannedMeal = meal;
    plannedDay._isCompleted = false;
    plannedDay._isSkipped = false;
    
    return plannedDay;
  }

  public string Serialize()
  {
    throw new NotImplementedException();
  }

  public void Deserialize()
  {
    throw new NotImplementedException();
  }
}