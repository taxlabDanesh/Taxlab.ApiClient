﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Taxlab.ApiClientLibrary;

namespace Taxlab.ApiClientCli.Implementations
{
    public static class TestSetup
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        //choose api location
        private static readonly string BaseUrl = "https://localhost:44359/";
        //private static readonly string BaseUrl = "https://preview.taxlab.online/api-internal/";

        //add B2C token or jwtToken based on scenario
        private static readonly string Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6Ilg1ZVhrNHh5b2pORnVtMWtsMll0djhkbE5QNC1jNTdkTzZRR1RWQndhTmsifQ.eyJleHAiOjE2Nzc3NTY3MTgsIm5iZiI6MTY3Nzc1MzExOCwidmVyIjoiMS4wIiwiaXNzIjoiaHR0cHM6Ly90YXhsYWJwdWJsaWMuYjJjbG9naW4uY29tL2I3MmMzZmY4LTM2NjEtNDRhYi05ZGYzLWU2YjM4NWI1ZTc2Zi92Mi4wLyIsInN1YiI6IjNkNjY1ZWE5LWY2NjYtNDM1Ny1iN2UyLTJhZjUyYzg3ZjA1MCIsImF1ZCI6ImYyYTNlYjU1LWE1ODAtNGE1My04NTc0LThlZTYyZTk0ZDMzNyIsIm5vbmNlIjoiNjM4MTMzNDk5MDk5MjM2NTU1Lk5tWTVOMlJsTjJNdFpUWm1OeTAwTlRaaExXRTFOakF0WW1KalpETTNOVGxsTm1aa05XRXlZakF5T1dRdE16SmpNQzAwTjJVd0xXSXpOakV0WmpNM01qVmxOVGs0TnpnMiIsImlhdCI6MTY3Nzc1MzExOCwiYXV0aF90aW1lIjoxNjc3NzUzMTE2LCJpZHBfYWNjZXNzX3Rva2VuIjoiUEFRQUJBQUFBQUFELS1ETEEzVk83UXJkZGdKZzdXZXZycktreXJuNFhmVy1UYnBSdG1oUUpnalh1akhfNDRWNk9raWRaMV9iLV9lMi1Fc0RneTZlcUhQZlk0bjd3WVl6aWwtQl8yd1RrMUc0Mmx1eVZtS2NCWUV5QXl3dm5XTTdTMTItaGVsMjk4WkNMWENERXo0NVdIV1NGMDVnRWgwTWNnOHU0SHNPWjRYNGRmZUh4YlZSRHg4WTRtVzVFbWxDQ2VqR2dnQjlNZHRscElQamRYYXhfemNmUThYZlllQnhvUjNfTmxjLXI1OWZWNVRBLTg4LTgyWWNZbG80cVVfSW1MTnpHMndRWEVmUVJUalBYc2ZHWnNDSllLSDd3RC0yVHZZZWdyY2xtczhPODNpTDl1alpSaVIxaWtkeF9ISWFTekNnS3FDVmd2Z3JhMVBxSW8zanVtV2xRWEh3WkxKZ09kdzU2Z25USjNBWWNGcC1NTzhhQ3pWLU1PM0J0RVc4Ukg3aFJ0aUx4VC1qcy1Ga3ZSZ2Jtald5d0pvTmhOeHBxTmw5Z1BXcFVUNUcwbThxUHduejE0RjUzYjlUMUlnR2xiSWJqRDJTMVVXSTB1Y21WRDMxZXlEb3lpX0huUHQ4UTBxMDhzYWlBbDlzOVF1bHFRc252ZzZ6X0NNWmIzaVRhakNVbm81UkZ2djUybDBNUFdtUE8xSmRHNEJIdXRhc3BuMS1WZDFnNWhUckJYRXlSNkxSRl9INjVvU1ZzUk93c0RZV29ndjY1cWdsVkdQMnRIei1EYnFmTzFidGdTSzg0YmJwdTY3RVZrMFpSTEp6OTNXbUIwNm53d195alRrNTRkZXBMSzF3TWdHdVFwNlZMUlh1aXJCSUluaW4wM1RaTG1XU1JNb0RLTUc0dWJZSTllR21NcFREb01aeUZzZHFXUkpHeXlGemVGMzk5Wm1IN0JfVjJITDI2WTZWcVBZVm13Yy02RnBBOWYyWGNjbURFVXZ1aDE2S1prdXVMS2JEZnQza1R1S2pZb29fZ29oUU1Ya0Z6OWdwWlZ0R0tEVktBVzd0NFZYMFRrMmZfX0dEOWNKSkVZeUFBIiwiaWRwIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvZThhMjZiZTYtMmEzZC00MTQ0LThlMzctZTIxNmUyMmZhMWRlLyIsImdpdmVuX25hbWUiOiJEYW5lc2giLCJmYW1pbHlfbmFtZSI6IkJhbGFzaW5nYW0iLCJuYW1lIjoiRGFuZXNoIEJhbGFzaW5nYW0iLCJvaWQiOiIzZDY2NWVhOS1mNjY2LTQzNTctYjdlMi0yYWY1MmM4N2YwNTAiLCJleHRlbnNpb25fdGVybXNPZlVzZSI6dHJ1ZSwiZW1haWxzIjpbImRhbmVzaC5iYWxhc2luZ2FtQHRheGxhYi5vbmxpbmUiXSwidGZwIjoiQjJDXzFfTG9jYWxTaWdudXBXaXRoTWZhVE9UUCJ9.ZK1nt9DD8VnKwmuYuLjctQTg-6RlV7c7jSzdyjoA576W1DObXkPre49sgXQGwE3oNVaT5jNidSSO7TonGGuhBYUDk4N9l8bDX9GZXCmx1dQRY6r8Zcf5rvyYBCbi7dRpGhS2HQmXsJGceGUyiBfZafEM0tp_jKNEBa8dZ58D2UoyuL75MhDk5kp8Oy912OH_rlF1CXB6aCpVwBXbjOJdIUCGr7FfsNCW-yI12z-WrdPd7bdd4kR_AcrIT4uArQdio17lReMDjZLZUpWl5auJZEZGvD_3E-5-29mTd4WRdni1H5eYh7rHsy9ikJ3ALSREPDA0SZcP-8oWdqd_EC29KA";

        public static TaxlabApiClient GetTaxlabApiClient()
        {
            var authService = new AuthService(Token);
            return new TaxlabApiClient(BaseUrl, HttpClient, authService);

        }
    }
}
