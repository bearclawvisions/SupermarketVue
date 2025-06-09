import type {ColumnConfig} from "@/types/Models.ts";

export function defineColumns<T>(...columns: ColumnConfig<T>[]): ColumnConfig<T>[] {
    return columns;
}
