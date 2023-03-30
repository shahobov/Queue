namespace Queue.Application.ResponseModels.WorkerSkillsResponseModels;

public class GetWorkerSkillsResponseModel:WorkerSkillsResponseModel
{
    public ulong WorkerID { get; set; }
    public ulong ServiceID { get; set; }
}