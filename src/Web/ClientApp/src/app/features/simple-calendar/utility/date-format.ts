type DateInput = Date | string | number;

interface DayOfWeekOptions {
    locale?: string;
    timeZone?: string;
}

/**
 * Converts various date inputs into a localized weekday name.
 */
export function getDayOfWeek(input: DateInput, options: DayOfWeekOptions = {}): string {
    const date = normalizeDateInput(input);

    if (Number.isNaN(date.getTime())) {
        throw new RangeError(`Invalid date input: ${String(input)}`);
    }

    const locale = options.locale ?? 'en-US';
    const timeZone =
        options.timeZone ?? Intl.DateTimeFormat().resolvedOptions().timeZone;

    const formatter = new Intl.DateTimeFormat(locale, {
        day: '2-digit',
        weekday: 'long',
        timeZone,
    });

    // format() respects locale/timezone and returns the human-readable weekday.
    return formatter.format(date);
}

/**
 * Normalizes Date, string, and numeric inputs into a Date instance.
 */
function normalizeDateInput(input: DateInput): Date {
    if (input instanceof Date) {
        // Clone to avoid mutating the caller's Date.
        return new Date(input.getTime());
    }

    if (typeof input === 'number' || typeof input === 'string') {
        return new Date(input);
    }

    throw new TypeError(
        `Unsupported date input type: ${typeof input}`
    );
}

export function formatTimeLabel(totalMinutes: number, minutesPerDay: number): string {
    const boundedMinutes = Math.max(0, Math.min(totalMinutes, minutesPerDay));
    const hours24 = Math.floor(boundedMinutes / 60);
    const minutes = boundedMinutes % 60;

    // Treat 24:00 as the next day's midnight for 12-hour display.
    const effectiveHours = hours24 === 24 && minutes === 0 ? 0 : hours24;
    const period = effectiveHours >= 12 ? 'PM' : 'AM';
    const hours12 = effectiveHours % 12 === 0 ? 12 : effectiveHours % 12;

    return `${hours12}:${minutes.toString().padStart(2, '0')} ${period}`;
}
