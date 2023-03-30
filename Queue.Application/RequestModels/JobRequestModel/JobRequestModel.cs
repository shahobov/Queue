namespace Queue.Application.RequestModels.JobRequestModel;

public class JobRequestModel:BaseRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}