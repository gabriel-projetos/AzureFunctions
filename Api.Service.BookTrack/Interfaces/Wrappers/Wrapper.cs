using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Wrappers
{
    public class Wrapper<TData>
    {
        [JsonIgnore]
        public TData Data { get; set; }

        public Wrapper()
        {
            Data = Activator.CreateInstance<TData>();
        }

        public Wrapper(TData data)
        {
            Data = data;
        }

        public virtual Task Populate(TData data)
        {
            Data = data;
            return Task.CompletedTask;
        }

        public virtual Task<TData> Result()
        {
            return Task.FromResult(Data);
        }

        public virtual Task<string> AsJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return Task.FromResult(json);
        }

        public static async Task<TResult> Create<TResult>(TData data) where TResult : Wrapper<TData>
        {
            TResult wrapper = default(TResult);

            try
            {
                wrapper = Activator.CreateInstance(typeof(TResult), new object[] { default(TData) }) as TResult;
            }
            catch (Exception)
            {
                wrapper = Activator.CreateInstance(typeof(TResult)) as TResult;
            }

            await wrapper.Populate(data).ConfigureAwait(false);

            return wrapper;
        }
    }
}
