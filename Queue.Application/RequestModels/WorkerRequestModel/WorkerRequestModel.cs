using Queue.Domain.Model;

namespace Queue.Application.RequestModels.WorkerRequestModel;

public class WorkerRequestModel:BaseRequestModel
{
    public Job Job { get; set; }
    public Schedule Schedule { get; set; }
}