import { FC, Fragment } from "react";
import { ITask } from "../Global/Interfaces";
import {
    CalendarIcon,
    EllipsisHorizontalIcon,
    ForwardIcon,
    MusicalNoteIcon,
    PencilIcon,
    SunIcon,
} from "@heroicons/react/24/outline";
import { parseDate } from "../Global/DateOption";
import {
    format,
    isSameDay,
    isToday,
    isTomorrow,
    nextDay,
    startOfDay,
    subDays,
} from "date-fns";
import clsx from "clsx";
import axios from "axios";
import { useDispatch } from "react-redux";
import { setTaskTodo } from "../States/TaskTodoReducer";
import { setTaskTodoComplete } from "../States/TaskTodoHandleComplete";

const Task: FC<ITask> = ({
    id,
    name,
    due_Date,
    description,
    priority,
    isCompleted,
    section_id,
}) => {
    const dispatch = useDispatch();
    const fullDateTime = new Date(due_Date);

    const handleOpenModalTask = () => {
        console.log("Modal");
    };
    const hanldeEditTask = (event: React.MouseEvent<HTMLButtonElement>) => {
        //Cancel parent event
        event.stopPropagation();

        console.log("edit");
    };

    const hanldeOpenDueDateModal = (
        event: React.MouseEvent<HTMLButtonElement>
    ) => {
        //Cancel parent event
        event.stopPropagation();

        console.log("DueDate");
    };
    const hanldeOption = (event: React.MouseEvent<HTMLButtonElement>) => {
        //Cancel parent event
        event.stopPropagation();

        console.log("Option");
    };

    const handleCompletedTaskTodo = (
        event: React.MouseEvent<HTMLButtonElement>
    ) => {
        event.stopPropagation();
        axios({
            method: "PUT",
            url: `TaskTodo/complete/${id}`,
        })
            .then(() => {
                dispatch(setTaskTodoComplete({ id, isCompleted: true }));
            })
            .catch((error) => {
                console.error("Cannot set completed for this task: ", error);
            });
    };

    return (
        <div
            className="select-none w-full cursor-pointer group "
            onClick={handleOpenModalTask}
        >
            <div className=" flex flex-col mt-2 ">
                {/* CHECK-BUTTON */}
                <div className="flex items-center">
                    <div className="flex flex-auto items-center gap-2">
                        <button
                            type="button"
                            onClick={handleCompletedTaskTodo}
                            className="left-0 top-2 text-sm text-neutral-500"
                        >
                            <div
                                className={clsx(
                                    "p-[8px] border-[2px] rounded-full w-4 h-4  transition-all duration-200 ease-linear hover:w-6 hover:h-6 ",
                                    {
                                        "border-red-600 hover:bg-red-600 hover:bg-opacity-30":
                                            priority === "P1",
                                        "border-yellow-200 hover:bg-yellow-200 hover:bg-opacity-30":
                                            priority === "P2",
                                        "border-primary hover:bg-primary hover:bg-opacity-30":
                                            priority === "P3",
                                        "border-neutral-500 hover:bg-neutral-500 hover:bg-opacity-30":
                                            priority === "P4",
                                    }
                                )}
                            ></div>
                        </button>
                        <p className="text-base">
                            {name.length >= 30
                                ? name.substring(0, 30) + "..."
                                : name}
                        </p>
                    </div>
                    <div className=" flex gap-4 opacity-60 z-50">
                        <span
                            className="w-6 h-6 child Desktop:hidden Desktop:group-hover:block Desktop:hover:bg-neutral-200"
                            onClick={hanldeEditTask}
                        >
                            <PencilIcon />
                        </span>
                        <span
                            className="w-6 h-6 child Desktop:hidden Desktop:group-hover:block Desktop:hover:bg-neutral-200"
                            onClick={hanldeOpenDueDateModal}
                        >
                            <CalendarIcon />
                        </span>
                        <span
                            className="w-6 h-6 child Desktop:hidden Desktop:group-hover:block Desktop:hover:bg-neutral-200"
                            onClick={hanldeOption}
                        >
                            <EllipsisHorizontalIcon />
                        </span>
                    </div>
                </div>

                <div className="ml-6">
                    <p className="text-sm ml-1 text-gray-400">
                        {" "}
                        {description.length >= 44
                            ? description.substring(0, 44) + "..."
                            : description}
                    </p>
                    <div className="flex gap-2 items-center text-sm ml-1 my-1">
                        {isToday(fullDateTime) ? (
                            <div className="flex items-center text-lime-500 ">
                                <span>
                                    <CalendarIcon className="w-4 h-4 " />
                                </span>
                                <p className="ml-2 ">Today</p>
                            </div>
                        ) : isTomorrow(fullDateTime) ? (
                            <div className="flex items-center text-yellow-500 ">
                                <span>
                                    <SunIcon className="w-4 h-4 " />
                                </span>
                                <p className="ml-2 ">Tomorrow</p>
                            </div>
                        ) : isSameDay(
                              subDays(nextDay(startOfDay(new Date()), 1), 1),
                              fullDateTime
                          ) ? (
                            <div className="flex items-center text-primary ">
                                <span>
                                    <MusicalNoteIcon className="w-4 h-4 " />
                                </span>
                                <p className="ml-2 ">
                                    {fullDateTime.toLocaleDateString("en-US", {
                                        weekday: "long",
                                    })}
                                </p>
                            </div>
                        ) : isSameDay(
                              nextDay(startOfDay(new Date()), 1),
                              fullDateTime
                          ) ? (
                            <div className="flex items-center text-purple-500 ">
                                <span>
                                    <ForwardIcon className="w-4 h-4 " />
                                </span>
                                <p className="ml-2 ">
                                    {fullDateTime.toLocaleDateString("en-US", {
                                        weekday: "long",
                                    })}
                                </p>
                            </div>
                        ) : (
                            <div className="flex items-center opacity-50 ">
                                <span>
                                    <CalendarIcon className="w-4 h-4 " />
                                </span>
                                <p className="ml-2 ">
                                    {format(parseDate(due_Date), "d LLL")}
                                </p>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Task;
