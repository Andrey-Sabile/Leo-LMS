using System;
using LeoLMS.Domain.Entities;
using LeoLMS.Domain.Enums;
using LeoLMS.Domain.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace LeoLMS.Domain.UnitTests.Entities;

public class CalendarEventTests
{
    [Test]
    public void Create_WithValidInputs_ReturnsCalendarEvent()
    {
        var start = new DateTimeOffset(2024, 1, 1, 8, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        var calendarEvent = CalendarEvent.Create("Math Exam", "Chapter 5 assessment", timeRange);

        calendarEvent.ShouldNotBeNull();
        calendarEvent.Title.ShouldBe("Math Exam");
        calendarEvent.Description.ShouldBe("Chapter 5 assessment");
        calendarEvent.TimeRange.ShouldBe(timeRange);
        calendarEvent.Type.ShouldBeNull();
        calendarEvent.Scope.ShouldBeNull();
    }

    [Test]
    public void Create_WithWhitespaceWrappedInputs_TrimsValues()
    {
        var start = new DateTimeOffset(2024, 1, 2, 10, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(2);
        var timeRange = EventTimeRange.Create(start, end);

        var calendarEvent = CalendarEvent.Create("  Science Fair  ", "  Annual showcase  ", timeRange);

        calendarEvent.Title.ShouldBe("Science Fair");
        calendarEvent.Description.ShouldBe("Annual showcase");
    }

    [Test]
    public void Create_WithEmptyTitle_ThrowsArgumentException()
    {
        var start = new DateTimeOffset(2024, 1, 3, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        var exception = Should.Throw<ArgumentException>(() => CalendarEvent.Create(" ", "Description", timeRange));

        exception.ParamName.ShouldBe("title");
    }

    [Test]
    public void Create_WithEmptyDescription_ThrowsArgumentException()
    {
        var start = new DateTimeOffset(2024, 1, 4, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        var exception = Should.Throw<ArgumentException>(() => CalendarEvent.Create("Title", "", timeRange));

        exception.ParamName.ShouldBe("description");
    }

    [Test]
    public void Create_WithNullTimeRange_ThrowsArgumentNullException()
    {
        Should.Throw<ArgumentNullException>(() => CalendarEvent.Create("Title", "Description", null!))
            .ParamName.ShouldBe("timeRange");
    }

    [Test]
    public void Create_WithClassScopeAndMissingClassId_ThrowsArgumentException()
    {
        var start = new DateTimeOffset(2024, 1, 5, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        Should.Throw<ArgumentException>(() => CalendarEvent.Create("Title", "Description", timeRange, scope: EventScope.Class))
            .ParamName.ShouldBe("classId");
    }

    [Test]
    public void Create_WithSubjectScopeAndMissingSubjectId_ThrowsArgumentException()
    {
        var start = new DateTimeOffset(2024, 1, 6, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        Should.Throw<ArgumentException>(() => CalendarEvent.Create("Title", "Description", timeRange, scope: EventScope.Subject))
            .ParamName.ShouldBe("subjectId");
    }

    [Test]
    public void Create_WithSubjectScopeAssignsIdentifiers()
    {
        var start = new DateTimeOffset(2024, 1, 7, 9, 0, 0, TimeSpan.Zero);
        var end = start.AddHours(1);
        var timeRange = EventTimeRange.Create(start, end);

        var calendarEvent = CalendarEvent.Create("Title", "Description", timeRange, scope: EventScope.Subject, subjectId: 42, classId: 7);

        calendarEvent.Scope.ShouldBe(EventScope.Subject);
        calendarEvent.SubjectId.ShouldBe(42);
        calendarEvent.ClassId.ShouldBe(7);
    }
}
