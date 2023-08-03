import { CalendarIcon } from "@heroicons/react/24/solid";
import CalendarComponent from "../CalendarComponent";
import {
    SunIcon,
    ForwardIcon,
    MusicalNoteIcon,
} from "@heroicons/react/24/outline";
import {
    startOfToday,
    startOfTomorrow,
    startOfWeek,
    addWeeks,
    getDay,
    addDays,
    endOfDay,
} from "date-fns";
import { useDispatch } from "react-redux";
import { setDueDate } from "../../States/DueDateReducer";

const ModalDueDateComponent = () => {
    const dispatch = useDispatch();
    let today = startOfToday();
    let tomorrow = startOfTomorrow();
    let firstDayOfNextWeek = startOfWeek(addWeeks(new Date(), 1), {
        weekStartsOn: 1,
    });
    let lastDayOfWeek = new Date(
        addDays(
            today.setDate(today.getDate() + ((6 - getDay(new Date())) % 7)),
            1
        )
    );

    const hanldeChangeOptionDueDate = (fullDateTime: Date) => {
        dispatch(
            setDueDate({
                type: "OPTIONS",
                fullDateTime: endOfDay(fullDateTime).toString(),
            })
        );
    };

    return (
        <div
            data-te-modal-init
            className="select-none fixed left-0 bottom-[3.4rem] z-[1055] hidden h-full w-full overflow-y-auto overflow-x-hidden outline-none"
            id="calendaroption"
            aria-labelledby="calendaroption"
            aria-modal="true"
            role="dialog"
        >
            <div
                data-te-modal-dialog-ref
                className="pointer-events-none relative flex min-h-[calc(100%-1rem)] w-auto translate-y-[-50px] items-center opacity-0 transition-all duration-300 ease-in-out min-[576px]:mx-auto min-[576px]:mt-7 min-[576px]:min-h-[calc(100%-3.5rem)] min-[576px]:max-w-[500px]"
            >
                <div className="pointer-events-auto relative flex w-full flex-col rounded-md border-none bg-white bg-clip-padding text-current shadow-lg outline-none dark:bg-neutral-600">
                    <div className="flex flex-col flex-shrink-0  rounded-t-md border-b-2 border-neutral-100 border-opacity-100 p-4 dark:border-opacity-50">
                        {/* TODAY */}
                        <div
                            className="relative"
                            onClick={() =>
                                hanldeChangeOptionDueDate(new Date())
                            }
                            data-te-modal-dismiss
                        >
                            <div className="flex h-10 w-full cursor-pointer items-center truncate rounded-[5px] px-6 py-2 text-[0.875rem] text-gray-600 outline-none transition duration-100 ease-linear hover:bg-slate-300 hover:text-inherit hover:outline-none focus:bg-slate-300 focus:text-inherit focus:outline-none active:bg-slate-300 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10">
                                <span className="mr-4 h-6 w-6 text-lime-500 dark:text-gray-300">
                                    <CalendarIcon className="" />
                                </span>
                                <span className="font-bold">Today</span>
                                <span className="absolute right-0 mr-4 opacity-60">
                                    {new Date().toLocaleDateString("en-US", {
                                        weekday: "short",
                                    })}
                                </span>
                            </div>
                        </div>

                        {/* TOMORROW */}
                        <div
                            className="relative"
                            onClick={() => hanldeChangeOptionDueDate(tomorrow)}
                            data-te-modal-dismiss
                        >
                            <div className="flex h-10 w-full cursor-pointer items-center truncate rounded-[5px] px-6 py-2 text-[0.875rem] text-gray-600 outline-none transition duration-100 ease-linear hover:bg-slate-300 hover:text-inherit hover:outline-none focus:bg-slate-300 focus:text-inherit focus:outline-none active:bg-slate-300 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10">
                                <span className="mr-4 h-6 w-6 text-yellow-500 dark:text-gray-300">
                                    <SunIcon className="" />
                                </span>
                                <span className="font-bold">Tomorrow</span>
                                <span className="absolute right-0 mr-4 opacity-60">
                                    {tomorrow.toLocaleDateString("en-US", {
                                        weekday: "short",
                                        day: "2-digit",
                                    })}
                                </span>
                            </div>
                        </div>

                        {/* THIS-WEEKEND */}
                        <div
                            className="relative"
                            onClick={() =>
                                hanldeChangeOptionDueDate(lastDayOfWeek)
                            }
                            data-te-modal-dismiss
                        >
                            <div className="flex h-10 w-full cursor-pointer items-center truncate rounded-[5px] px-6 py-2 text-[0.875rem] text-gray-600 outline-none transition duration-100 ease-linear hover:bg-slate-300 hover:text-inherit hover:outline-none focus:bg-slate-300 focus:text-inherit focus:outline-none active:bg-slate-300 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10">
                                <span className="mr-4 h-6 w-6 text-primary dark:text-gray-300">
                                    <MusicalNoteIcon className="" />
                                </span>
                                <span className="font-bold">This Weekend</span>
                                <span className="absolute right-0 mr-4 opacity-60">
                                    {lastDayOfWeek.toLocaleDateString("en-US", {
                                        weekday: "short",
                                        day: "2-digit",
                                    })}
                                </span>
                            </div>
                        </div>

                        {/* NEXT_WEEK */}
                        <div
                            className="relative"
                            onClick={() =>
                                hanldeChangeOptionDueDate(firstDayOfNextWeek)
                            }
                            data-te-modal-dismiss
                        >
                            <div className="flex h-10 w-full cursor-pointer items-center truncate rounded-[5px] px-6 py-2 text-[0.875rem] text-gray-600 outline-none transition duration-100 ease-linear hover:bg-slate-300 hover:text-inherit hover:outline-none focus:bg-slate-300 focus:text-inherit focus:outline-none active:bg-slate-300 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10">
                                <span className="mr-4 h-6 w-6 text-purple-500 dark:text-gray-300">
                                    <ForwardIcon className="" />
                                </span>
                                <span className="font-bold">Next week</span>
                                <span className="absolute right-0 mr-4 opacity-60">
                                    {firstDayOfNextWeek.toLocaleDateString(
                                        "en-US",
                                        {
                                            weekday: "short",
                                            month: "short",
                                            day: "2-digit",
                                        }
                                    )}
                                </span>
                            </div>
                        </div>
                    </div>

                    {/* MODAL BODY */}
                    <div className="relative p-4">
                        <CalendarComponent />
                    </div>

                    {/* MODAL FOOTER */}
                    <div className="flex flex-shrink-0 flex-wrap items-center justify-end rounded-b-md border-t-2 border-neutral-100 border-opacity-100 p-4 dark:border-opacity-50"></div>
                </div>
            </div>
        </div>
    );
};

export default ModalDueDateComponent;
