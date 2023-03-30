namespace Queue.Application.ResponseModels.WorkerSkillsResponseModels;

public class UpdateWorkerSkillsResponseModel:WorkerSkillsResponseModel
{
    public ulong WorkerID { get; set; }
    public ulong ServiceID { get; set; }
}