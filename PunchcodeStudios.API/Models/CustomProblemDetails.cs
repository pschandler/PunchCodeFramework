﻿using Microsoft.AspNetCore.Mvc;

namespace PunchcodeStudios.API.Models;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

}
