using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LocationFInderApp.Models;

namespace LocationFInderApp.Data
{
    public class RestUtil<TReturn, TInput>
    {
        //public static async Task<ResponseModel<TReturn>> Get(Uri uri, bool authRequire = false)
        // {
        //HttpClient _client = new HttpClient();
        //ResponseModel<TReturn> modelResponse = new ResponseModel<TReturn>();

        //  try
        //  {
        //     if (authRequire)
        //     {
        //_client.DefaultRequestHeaders.Authorization = GetAuthToken();
        //}

        // HttpResponseMessage response = null;
        // response = await _client.GetAsync(uri);

        //      if (response.IsSuccessStatusCode)
        //    {
        //var responseContent = await response.Content.ReadAsStringAsync();
        //modelResponse = JsonConvert.DeserializeObject<ResponseModel<TReturn>>(responseContent);


        //}
        //}
        //  catch (HttpRequestException ex)
        //  {
        //Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //}
        //  catch (ArgumentNullException ex)
        //  {
        //Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //}
        //catch (Exception ex)
        //{
        // Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //}

        //     return modelResponse;
        //}
        public static async Task<ResponseModel<TReturn>> Get(Uri uri, bool authRequire = false)
        {
            HttpClient _client = new HttpClient();
            ResponseModel<TReturn> modelResponse = new ResponseModel<TReturn>();

            try
            {
                if (authRequire)
                {
                    _client.DefaultRequestHeaders.Authorization = GetAuthToken();
                }

                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Check if the expected type is an array
                    if (typeof(TReturn).IsGenericType && typeof(TReturn).GetGenericTypeDefinition() == typeof(List<>))
                    {
                        // If it's a List, deserialize directly to the list
                        modelResponse.Data = JsonConvert.DeserializeObject<TReturn>(responseContent);
                    }
                    else
                    {
                        // If it's not a List, proceed with the original deserialization
                        modelResponse = JsonConvert.DeserializeObject<ResponseModel<TReturn>>(responseContent);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return modelResponse;
        }


        public static async Task<ResponseModel<TReturn>> Post(Uri uri, TInput param, bool authRequire = false)
        {
            HttpClient _client = new HttpClient();
            ResponseModel<TReturn> modelResponse = new ResponseModel<TReturn>();

            try
            {
                var json = JsonConvert.SerializeObject(param);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                if (authRequire)
                {
                    _client.DefaultRequestHeaders.Authorization = GetAuthToken();
                }

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    //modelResponse = JsonConvert.DeserializeObject<ResponseModel<TReturn>>(responseContent);
                    modelResponse.IsSuccess = true;
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return modelResponse;
        }

        public static async Task<ResponseModel<TReturn>> Put(Uri uri, TInput param, bool authRequire = false)
        {
            HttpClient _client = new HttpClient();
            ResponseModel<TReturn> modelResponse = new ResponseModel<TReturn>();

            try
            {
                var json = JsonConvert.SerializeObject(param);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                if (authRequire)
                {
                    _client.DefaultRequestHeaders.Authorization = GetAuthToken();
                }

                HttpResponseMessage response = null;
                response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    modelResponse = JsonConvert.DeserializeObject<ResponseModel<TReturn>>(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return modelResponse;
        }

        public static async Task<List<TReturn>> PostImage(Uri uri, Stream fStream, string extension, string keyValue1, string keyValue2, bool authRequire = false)
        {
            HttpClient _client = new HttpClient();
            List<TReturn> modelResponse = new List<TReturn>();

            try
            {
                MultipartFormDataContent formData = new MultipartFormDataContent();
                HttpContent content = new StreamContent(fStream);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = extension,
                };
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                formData.Add(content);
                formData.Add(new StringContent(keyValue1), keyValue1);
                if (keyValue2 != null)
                {
                    formData.Add(new StringContent(keyValue2), keyValue2);
                }

                if (authRequire)
                {
                    _client.DefaultRequestHeaders.Authorization = GetAuthToken();
                }

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, formData);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    modelResponse = JsonConvert.DeserializeObject<List<TReturn>>(responseContent);
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return modelResponse;
        }

       private static AuthenticationHeaderValue GetAuthToken()
        {
           return new AuthenticationHeaderValue("_token", SessionUtil.GetToken());
        }
    }
}
