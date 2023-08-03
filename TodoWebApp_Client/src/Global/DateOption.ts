import { format, parse } from "date-fns";

export const formatDate = (date: Date): string => {
    return format(date, "MM/dd/yyyy hh:mm:ss aa");
};

export const parseDate = (dateFormatted: string): Date => {
    return parse(dateFormatted, "MM/dd/yyyy hh:mm:ss aa", new Date());
};
