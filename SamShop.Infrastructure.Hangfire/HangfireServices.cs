using System.Linq.Expressions;
using Hangfire;
using SamShop.Domain.Core.Interfaces.Services;

namespace SamShop.Infrastructure.Hangfire
{
    public class HangfireServices:IJobServices
    {
        public string AddNewJub<T>(Expression<Action<T>> expression, DateTimeOffset enqueueAt)
        {
            return BackgroundJob.Schedule<T>(expression, enqueueAt);
        }
    }
}