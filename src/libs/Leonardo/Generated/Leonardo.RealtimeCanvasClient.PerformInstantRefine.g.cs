
#nullable enable

namespace Leonardo
{
    public partial class RealtimeCanvasClient
    {
        partial void PreparePerformInstantRefineArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Leonardo.PerformInstantRefineRequest request);
        partial void PreparePerformInstantRefineRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Leonardo.PerformInstantRefineRequest request);
        partial void ProcessPerformInstantRefineResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        partial void ProcessPerformInstantRefineResponseContent(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage,
            ref string content);

        /// <summary>
        /// Perform instant refine on a LCM image<br/>
        /// This endpoint will perform instant refine on a LCM image
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Leonardo.PerformInstantRefineResponse> PerformInstantRefineAsync(
            global::Leonardo.PerformInstantRefineRequest request,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: _httpClient);
            PreparePerformInstantRefineArguments(
                httpClient: _httpClient,
                request: request);

            using var httpRequest = new global::System.Net.Http.HttpRequestMessage(
                method: global::System.Net.Http.HttpMethod.Post,
                requestUri: new global::System.Uri(_httpClient.BaseAddress?.AbsoluteUri.TrimEnd('/') + "/lcm-instant-refine", global::System.UriKind.RelativeOrAbsolute));
            var __httpRequestContentBody = global::System.Text.Json.JsonSerializer.Serialize(request, global::Leonardo.SourceGenerationContext.Default.PerformInstantRefineRequest);
            var __httpRequestContent = new global::System.Net.Http.StringContent(
                content: __httpRequestContentBody,
                encoding: global::System.Text.Encoding.UTF8,
                mediaType: "application/json");
            httpRequest.Content = __httpRequestContent;

            PrepareRequest(
                client: _httpClient,
                request: httpRequest);
            PreparePerformInstantRefineRequest(
                httpClient: _httpClient,
                httpRequestMessage: httpRequest,
                request: request);

            using var response = await _httpClient.SendAsync(
                request: httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            ProcessResponse(
                client: _httpClient,
                response: response);
            ProcessPerformInstantRefineResponse(
                httpClient: _httpClient,
                httpResponseMessage: response);

            var __content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            ProcessResponseContent(
                client: _httpClient,
                response: response,
                content: ref __content);
            ProcessPerformInstantRefineResponseContent(
                httpClient: _httpClient,
                httpResponseMessage: response,
                content: ref __content);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (global::System.Net.Http.HttpRequestException ex)
            {
                throw new global::System.InvalidOperationException(__content, ex);
            }

            return
                global::System.Text.Json.JsonSerializer.Deserialize(__content, global::Leonardo.SourceGenerationContext.Default.PerformInstantRefineResponse) ??
                throw new global::System.InvalidOperationException($"Response deserialization failed for \"{__content}\" ");
        }

        /// <summary>
        /// Perform instant refine on a LCM image<br/>
        /// This endpoint will perform instant refine on a LCM image
        /// </summary>
        /// <param name="imageDataUrl">
        /// Image data used to generate image. In base64 format. Prefix: `data:image/jpeg;base64,`
        /// </param>
        /// <param name="prompt">
        /// The prompt used to generate images
        /// </param>
        /// <param name="guidance">
        /// How strongly the generation should reflect the prompt. Must be a float between 0.5 and 20.
        /// </param>
        /// <param name="strength">
        /// Creativity strength of generation. Higher strength will deviate more from the original image supplied in imageDataUrl. Must be a float between 0.1 and 1.
        /// </param>
        /// <param name="requestTimestamp"></param>
        /// <param name="style">
        /// The style to generate LCM images with.
        /// </param>
        /// <param name="steps">
        /// The number of steps to use for the generation. Must be between 4 and 16.
        /// </param>
        /// <param name="width">
        /// The output width of the image. Must be 512, 640 or 1024.<br/>
        /// Default Value: 512
        /// </param>
        /// <param name="height">
        /// The output width of the image. Must be 512, 640 or 1024.<br/>
        /// Default Value: 512
        /// </param>
        /// <param name="seed"></param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task<global::Leonardo.PerformInstantRefineResponse> PerformInstantRefineAsync(
            string imageDataUrl,
            string prompt,
            double? guidance = default,
            double? strength = default,
            string? requestTimestamp = default,
            global::Leonardo.LcmGenerationStyle? style = default,
            int? steps = default,
            int? width = 512,
            int? height = 512,
            int? seed = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = new global::Leonardo.PerformInstantRefineRequest
            {
                ImageDataUrl = imageDataUrl,
                Prompt = prompt,
                Guidance = guidance,
                Strength = strength,
                RequestTimestamp = requestTimestamp,
                Style = style,
                Steps = steps,
                Width = width,
                Height = height,
                Seed = seed,
            };

            return await PerformInstantRefineAsync(
                request: request,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}