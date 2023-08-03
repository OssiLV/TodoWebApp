import { CalendarIcon } from "@heroicons/react/24/solid";
import {
    isToday,
    isTomorrow,
    isSameDay,
    nextDay,
    startOfDay,
    subDays,
    isValid,
} from "date-fns";
import { FC, Fragment, useEffect } from "react";
import { RootState } from "../Global/Interfaces";
import { useSelector } from "react-redux";
import {
    ForwardIcon,
    MusicalNoteIcon,
    SunIcon,
} from "@heroicons/react/24/outline";
import { formatDate } from "../Global/DateOption";
interface IShowDueDateComponent {
    setDateTime: Function;
}
const ShowDueDateComponent: FC<IShowDueDateComponent> = ({ setDateTime }) => {
    const { fullDateTime } = useSelector(
        (state: RootState) => state.rootDueDateReducer
    );
    let dateTime = new Date(fullDateTime);
    useEffect(() => {
        if (isValid(dateTime)) {
            setDateTime(formatDate(dateTime));
        }
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [fullDateTime]);

    return (
        <Fragment>
            {isToday(dateTime) ? (
                <div className="flex items-center text-lime-500 font-bold px-2">
                    <span>
                        <CalendarIcon className="w-4 h-4 " />
                    </span>
                    <p className="ml-2 ">Today</p>
                </div>
            ) : isTomorrow(dateTime) ? (
                <div className="flex items-center text-yellow-500 font-bold px-2">
                    <span>
                        <SunIcon className="w-4 h-4 " />
                    </span>
                    <p className="ml-2 ">Tomorrow</p>
                </div>
            ) : isSameDay(
                  subDays(nextDay(startOfDay(new Date()), 1), 1),
                  dateTime
              ) ? (
                <div className="flex items-center text-primary font-bold px-2">
                    <span>
                        <MusicalNoteIcon className="w-4 h-4 " />
                    </span>
                    <p className="ml-2 ">
                        {dateTime.toLocaleDateString("en-US", {
                            weekday: "long",
                        })}
                    </p>
                </div>
            ) : isSameDay(nextDay(startOfDay(new Date()), 1), dateTime) ? (
                <div className="flex items-center text-purple-500 font-bold px-2">
                    <span>
                        <ForwardIcon className="w-4 h-4 " />
                    </span>
                    <p className="ml-2 ">
                        {dateTime.toLocaleDateString("en-US", {
                            weekday: "long",
                        })}
                    </p>
                </div>
            ) : (
                <div className="flex items-center opacity-50 font-bold px-2">
                    <span>
                        <CalendarIcon className="w-4 h-4 " />
                    </span>
                    <p className="ml-2 ">
                        {fullDateTime ===
                        "Mon Jul 1 0000 00:00:00 GMT+0700 (Indochina Time)"
                            ? "Due Date"
                            : dateTime.toLocaleDateString("en-US", {
                                  day: "2-digit",
                                  weekday: "short",
                              })}
                    </p>
                </div>
            )}
        </Fragment>
    );
};

export default ShowDueDateComponent;
