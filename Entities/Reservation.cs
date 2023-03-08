using System.Text;
using csharp_exceptions.Entities.Exceptions;

namespace csharp_exceptions.Entities;

public class Reservation
{
    public int RoomNumber { get; set; }
    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public Reservation () {} 
    public Reservation (int rooNumber, DateTime checkIn, DateTime checkOut )
    {
        if(checkOut <= checkIn) 
        {
            throw new DomainException("Check-out date must be after check-in date.");
        }
        RoomNumber = rooNumber;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public int Duration()
    {
        TimeSpan duration = CheckOut.Subtract(CheckIn);
        return (int)duration.TotalDays;
    
    }

    public void UpdateDates(DateTime checkIn, DateTime checkOut)
    {
        DateTime now = DateTime.Now;

        if(checkIn < now || checkOut < now)
        {
            throw new DomainException("Reservation dates for update must be future dates"); 
        }
        if(checkOut <= checkIn) 
        {
            throw new DomainException("Check-out date must be after check-in date.");
        }
        
        CheckIn = checkIn;
        CheckOut = checkOut;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(); 
        sb.Append($"Room {RoomNumber}, ");
        sb.Append($"check-in: {CheckIn.ToString("dd/MM/yyyy")}, ");
        sb.Append($"chek-out: {CheckOut.ToString("dd/MM/yyyy")}, ");
        sb.Append($"{Duration()} nights");

        return sb.ToString();
    }
}
