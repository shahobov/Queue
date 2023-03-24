using Queue.Domain.Model;

namespace Queue.Application.RequestModels.WorkerSkillsRequestModel;

public class WorkerSkillsRequestModel:BaseRequestModel
{
    public Service Services { get; set; }
    
    public Worker Workers { get; set; }
    
}