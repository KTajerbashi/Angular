import { Injectable } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import moment, { Moment } from 'jalali-moment';

@Injectable()
export class JalaliDateAdapter extends DateAdapter<Moment> {

  constructor() {
    super();
    moment.locale('fa');
  }

  // ===== Basic Getters =====

  override getYear(date: Moment): number {
    return date.jYear();
  }

  override getMonth(date: Moment): number {
    return date.jMonth();
  }

  override getDate(date: Moment): number {
    return date.jDate();
  }

  override getDayOfWeek(date: Moment): number {
    return date.day();
  }

  override getYearName(date: Moment): string {
    return String(date.jYear());
  }

  override getNumDaysInMonth(date: Moment): number {
    return date.jDaysInMonth();
  }

  override getFirstDayOfWeek(): number {
    return 6; // Saturday (Persian calendar starts Saturday)
  }

  // ===== Names =====

  override getMonthNames(): string[] {
    return [
      'فروردین','اردیبهشت','خرداد','تیر','مرداد','شهریور',
      'مهر','آبان','آذر','دی','بهمن','اسفند'
    ];
  }

  override getDateNames(): string[] {
    return Array.from({ length: 31 }, (_, i) => String(i + 1));
  }

  override getDayOfWeekNames(): string[] {
    return ['شنبه','یکشنبه','دوشنبه','سه‌شنبه','چهارشنبه','پنجشنبه','جمعه'];
  }

  // override getDayOfWeekNamesShort(): string[] {
  //   return ['ش','ی','د','س','چ','پ','ج'];
  // }

  // override getDayOfWeekNamesNarrow(): string[] {
  //   return ['ش','ی','د','س','چ','پ','ج'];
  // }

  // ===== Date Creation =====

  override createDate(year: number, month: number, date: number): Moment {
    const result = moment().jYear(year).jMonth(month).jDate(date);
    return result;
  }

  override today(): Moment {
    return moment();
  }

  override clone(date: Moment): Moment {
    return date.clone();
  }

  // ===== Adders =====

  override addCalendarYears(date: Moment, years: number): Moment {
    return date.clone().add(years, 'jYear');
  }

  override addCalendarMonths(date: Moment, months: number): Moment {
    return date.clone().add(months, 'jMonth');
  }

  override addCalendarDays(date: Moment, days: number): Moment {
    return date.clone().add(days, 'day');
  }

  // ===== Parsing & Formatting =====

  override parse(value: any): Moment | null {
    if (!value) return null;

    if (moment.isMoment(value)) return value;

    const parsed = moment(value, 'jYYYY/jMM/jDD', true);
    return parsed.isValid() ? parsed : null;
  }

  override format(date: Moment, displayFormat: string): string {
    if (!this.isValid(date)) return '';
    return date.format(displayFormat || 'jYYYY/jMM/jDD');
  }

  override toIso8601(date: Moment): string {
    return date.toISOString();
  }

  // ===== Validation =====

  override isDateInstance(obj: any): boolean {
    return moment.isMoment(obj);
  }

  override isValid(date: Moment): boolean {
    return date.isValid();
  }

  override invalid(): Moment {
    return moment.invalid();
  }

  // ===== Optional but recommended =====

  override deserialize(value: any): Moment | null {
    if (value instanceof Date) {
      return moment(value);
    }
    return this.parse(value);
  }
}
