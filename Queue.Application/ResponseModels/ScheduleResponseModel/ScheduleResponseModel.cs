using System;
using Queue.Domain.Model;

namespace Queue.Application.ResponseModels.ScheduleResponseModel;

public class ScheduleResponseModel:BaseResponseModel
{
    public Worker Worker { get; set; }
    public DateTime StartOfWork { get; set; }
    public DateTime EndOfWork { get; set; }
    public int Hour { get; set; }
    public DayOfTheWeek RestDay { get; set; }
}