import { ChevronLeftIcon, ChevronRightIcon } from "@heroicons/react/24/solid";
import {
    add,
    eachDayOfInterval,
    endOfMonth,
    format,
    getDay,
    isEqual,
    isSameMonth,
    isToday,
    parse,
    startOfToday,
    endOfDay,
} from "date-fns";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { setDueDate } from "../States/DueDateReducer";

function classNames(...classes: any) {
    return classes.filter(Boolean).join(" ");
}

export default function CalendarComponent() {
    const dispatch = useDispatch();
    let today = startOfToday();
    let [currentMonth, setCurrentMonth] = useState(format(today, "MMM-yyyy"));
    let firstDayCurrentMonth = parse(currentMonth, "MMM-yyyy", new Date());

    let days = eachDayOfInterval({
        start: firstDayCurrentMonth,
        end: endOfMonth(firstDayCurrentMonth),
    });

    const handleChangeDay = (fullDateTime: Date) => {
        dispatch(
            setDueDate({
                type: "CALENDAR",
                fullDateTime: endOfDay(fullDateTime).toString(),
            })
        );
    };

    const previousMonth = () => {
        let firstDayNextMonth = add(firstDayCurrentMonth, { months: -1 });
        setCurrentMonth(format(firstDayNextMonth, "MMM-yyyy"));
    };

    const nextMonth = () => {
        let firstDayNextMonth = add(firstDayCurrentMonth, { months: 1 });
        setCurrentMonth(format(firstDayNextMonth, "MMM-yyyy"));
    };

    return (
        <div className="max-w-xs mx-auto ">
            <div className="flex items-center">
                <h2 className="flex-auto font-semibold text-gray-900">
                    {format(firstDayCurrentMonth, "MMMM yyyy")}
                </h2>
                <button
                    type="button"
                    onClick={previousMonth}
                    className="-my-1.5 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500"
                >
                    <span className="sr-only">Previous month</span>
                    <ChevronLeftIcon className="w-5 h-5" aria-hidden="true" />
                </button>
                <button
                    onClick={nextMonth}
                    type="button"
                    className="-my-1.5 -mr-1.5 ml-2 flex flex-none items-center justify-center p-1.5 text-gray-400 hover:text-gray-500"
                >
                    <span className="sr-only">Next month</span>
                    <ChevronRightIcon className="w-5 h-5" aria-hidden="true" />
                </button>
            </div>
            <div className="grid grid-cols-7 mt-10 text-xs leading-6 text-center text-gray-500">
                <div>S</div>
                <div>M</div>
                <div>T</div>
                <div>W</div>
                <div>T</div>
                <div>F</div>
                <div>S</div>
            </div>
            <div className="grid grid-cols-7 text-sm" data-te-modal-dismiss>
                {days.map((day, dayIdx) => (
                    <div
                        onClick={() => handleChangeDay(day)}
                        key={day.toString()}
                        className={classNames(
                            dayIdx === 0 && colStartClasses[getDay(day)],
                            "py-1.5"
                        )}
                    >
                        <button
                            type="button"
                            className={classNames(
                                isEqual(day, today) && "text-white",
                                !isEqual(day, today) &&
                                    isToday(day) &&
                                    "text-red-500",
                                !isEqual(day, today) &&
                                    !isToday(day) &&
                                    isSameMonth(day, firstDayCurrentMonth) &&
                                    "text-gray-900 hover:bg-slate-50",
                                !isEqual(day, today) &&
                                    !isToday(day) &&
                                    !isSameMonth(day, firstDayCurrentMonth) &&
                                    "text-gray-400",
                                isEqual(day, today) &&
                                    isToday(day) &&
                                    "bg-red-500",
                                isEqual(day, today) &&
                                    !isToday(day) &&
                                    "bg-gray-900 hover:bg-slate-50",
                                !isEqual(day, today) && "hover:bg-gray-200",
                                (isEqual(day, today) || isToday(day)) &&
                                    "font-semibold",
                                "mx-auto p-4 flex h-8 w-8 items-center justify-center rounded-full "
                            )}
                        >
                            <time dateTime={format(day, "yyyy-MM-dd")}>
                                {format(day, "d")}
                            </time>
                        </button>
                    </div>
                ))}
            </div>
        </div>
    );
}

let colStartClasses = [
    "",
    "col-start-2",
    "col-start-3",
    "col-start-4",
    "col-start-5",
    "col-start-6",
    "col-start-7",
];
