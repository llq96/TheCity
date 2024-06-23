using System;
using TheCity.Core;

namespace TheCity.Unity
{
    public record ScheduleActivity(
        DateTime DateTime,
        Activity Activity
    );
}