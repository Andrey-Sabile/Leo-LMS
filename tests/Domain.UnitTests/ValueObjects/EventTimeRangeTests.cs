using System;
using LeoLMS.Domain.Exceptions;
using LeoLMS.Domain.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace LeoLMS.Domain.UnitTests.ValueObjects;

public class EventTimeRangeTests
{
    [Test]
    public void Create_WithValidStartAndEnd_ReturnsEventTimeRange()
    {
        var start = new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(2);

        var range = EventTimeRange.Create(start, end);

        range.Start.ShouldBe(start);
        range.End.ShouldBe(end);
        range.Duration.ShouldBe(end - start);
    }

    [Test]
    public void Create_WithDefaultStart_ThrowsInvalidEventTimeRangeException()
    {
        var end = new DateTimeOffset(2024, 1, 1, 10, 0, 0, TimeSpan.Zero);

        Should.Throw<InvalidEventTimeRangeException>(() => EventTimeRange.Create(default, end));
    }

    [Test]
    public void Create_WithDefaultEnd_ThrowsInvalidEventTimeRangeException()
    {
        var start = new DateTimeOffset(2024, 1, 1, 10, 0, 0, TimeSpan.Zero);

        Should.Throw<InvalidEventTimeRangeException>(() => EventTimeRange.Create(start, default));
    }

    [Test]
    public void Create_WithStartAfterEnd_ThrowsInvalidEventTimeRangeException()
    {
        var start = new DateTimeOffset(2024, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(-1);

        Should.Throw<InvalidEventTimeRangeException>(() => EventTimeRange.Create(start, end));
    }

    [Test]
    public void Shift_WithPositiveOffset_ReturnsShiftedRange()
    {
        var start = new DateTimeOffset(2024, 1, 1, 8, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var range = EventTimeRange.Create(start, end);

        var shifted = range.Shift(TimeSpan.FromHours(2));

        shifted.Start.ShouldBe(start.AddHours(2));
        shifted.End.ShouldBe(end.AddHours(2));
    }

    [Test]
    public void Shift_WithNegativeOffset_ReturnsShiftedRange()
    {
        var start = new DateTimeOffset(2024, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(3);
        var range = EventTimeRange.Create(start, end);

        var shifted = range.Shift(TimeSpan.FromHours(-1));

        shifted.Start.ShouldBe(start.AddHours(-1));
        shifted.End.ShouldBe(end.AddHours(-1));
    }

    [Test]
    public void Overlaps_WhenRangesOverlap_ReturnsTrue()
    {
        var range1 = EventTimeRange.Create(new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero), new DateTimeOffset(2024, 1, 1, 11, 0, 0, TimeSpan.Zero));
        var range2 = EventTimeRange.Create(new DateTimeOffset(2024, 1, 1, 10, 30, 0, TimeSpan.Zero), new DateTimeOffset(2024, 1, 1, 12, 0, 0, TimeSpan.Zero));

        range1.Overlaps(range2).ShouldBeTrue();
        range2.Overlaps(range1).ShouldBeTrue();
    }

    [Test]
    public void Overlaps_WhenRangesDoNotOverlap_ReturnsFalse()
    {
        var range1 = EventTimeRange.Create(new DateTimeOffset(2024, 1, 1, 8, 0, 0, TimeSpan.Zero), new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero));
        var range2 = EventTimeRange.Create(new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero), new DateTimeOffset(2024, 1, 1, 10, 0, 0, TimeSpan.Zero));

        range1.Overlaps(range2).ShouldBeFalse();
        range2.Overlaps(range1).ShouldBeFalse();
    }

    [Test]
    public void Equality_WithIdenticalValues_ReturnsTrue()
    {
        var start = new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);

        var left = EventTimeRange.Create(start, end);
        var right = EventTimeRange.Create(start, end);

        left.ShouldBe(right);
    }

    [Test]
    public void Equality_WithDifferentValues_ReturnsFalse()
    {
        var start = new DateTimeOffset(2024, 1, 1, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);

        var left = EventTimeRange.Create(start, end);
        var right = EventTimeRange.Create(start.AddHours(1), end.AddHours(1));

        left.ShouldNotBe(right);
    }
}
