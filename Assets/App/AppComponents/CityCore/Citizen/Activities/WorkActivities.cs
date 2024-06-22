namespace TheCity.Core
{
    public class WorkActivity : Activity
    {
    }

    public class Activity_StartWork : WorkActivity //Формальное начало рабочего дня
    {
    }

    public class Activity_EndWork : WorkActivity //Формальное окончание рабочего дня
    {
    }

    public class Activity_GoToWork : WorkActivity //Дойти до рабочего места
    {
    }

    public class Activity_Working : WorkActivity //Сидеть-работать ?
    {
    }
}