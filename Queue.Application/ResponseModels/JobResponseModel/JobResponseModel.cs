namespace Queue.Application.ResponseModels.JobResponseModel;

public abstract class JobResponseModel:BaseResponseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}