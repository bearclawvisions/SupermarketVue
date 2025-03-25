import { Severity } from '@/enums/Severity.ts';
import { getEnumKeyByValue } from '@/composables/enumHelper.ts';
import type { ToastServiceMethods } from 'primevue';

export class ToastHelper {
  private toastInstance: ToastServiceMethods;
  private defaultLifeTime: number;

  constructor(toastInstance: ToastServiceMethods, defaultLifeTime: number = 3000) {
    this.toastInstance = toastInstance;
    this.defaultLifeTime = defaultLifeTime;
  }

  displayInfo(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({ 
      severity: Severity.INFO,
      summary: getEnumKeyByValue(Severity, Severity.INFO),
      detail: body,
      life: lifeTime
    });
  }

  displayError(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({
      severity: Severity.ERROR,
      summary: getEnumKeyByValue(Severity, Severity.ERROR),
      detail: body,
      life: lifeTime
    });
  }

  displaySuccess(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({
      severity: Severity.SUCCESS,
      summary: getEnumKeyByValue(Severity, Severity.SUCCESS),
      detail: body,
      life: lifeTime
    });
  }

  displayWarning(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({
      severity: Severity.WARNING,
      summary: getEnumKeyByValue(Severity, Severity.WARNING),
      detail: body,
      life: lifeTime
    });
  }

  displayContrast(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({
      severity: Severity.CONTRAST,
      summary: getEnumKeyByValue(Severity, Severity.CONTRAST),
      detail: body,
      life: lifeTime
    });
  }

  displaySecondary(body: string = '', lifeTime: number = this.defaultLifeTime): void {
    this.toastInstance.add({
      severity: Severity.SECONDARY,
      summary: getEnumKeyByValue(Severity, Severity.SECONDARY),
      detail: body,
      life: lifeTime
    });
  }
}