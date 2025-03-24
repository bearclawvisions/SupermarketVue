import { Severity } from '@/enums/Severity.ts';
import { getEnumKeyByValue } from '@/composables/enumHelper.ts'
import type { ToastServiceMethods } from 'primevue'

// interface ToastInstance {
//   add: (options: {
//     severity: string;
//     summary: string | undefined;
//     detail: string;
//     life: number
//   }) => void;
// }

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
}