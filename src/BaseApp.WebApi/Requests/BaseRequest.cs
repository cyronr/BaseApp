using Newtonsoft.Json;

namespace BaseApp.WebAPI.Requests;

public record BaseRequest
{
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
