namespace Queue.Application.RequestModels.WorkerSkillsRequestModel;

public abstract class WorkerSkillsRequestModel:BaseRequestModel
{
    public ulong WorkerID { get; set; }
    public ulong ServiceID { get; set; }
}