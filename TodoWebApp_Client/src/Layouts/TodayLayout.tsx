import { useEffect, useState } from "react";
import {
    AdjustmentsHorizontalIcon,
    EllipsisHorizontalIcon,
} from "@heroicons/react/24/solid";
import { ITaskTodo, RootStates } from "../Global";
import axios from "axios";
import { useSelector } from "react-redux";

const TodayLayout = () => {
    const _user = useSelector((state: RootStates) => state.rootUserReducer);

    const [tasks, setTasks] = useState<Array<ITaskTodo>>([]);

    useEffect(() => {
        axios({
            method: "GET",
            url: `TaskTodo/userid/${_user.id}`,
        })
            .then((res) => {
                setTasks(res.data.objectData);
            })
            .catch((error) => console.error("Cannot get all Tasks: " + error));
    }, [_user.id]);

    return (
        <div id="content" className="pt-[55px] flex-col flex items-center">
            <div className="flex flex-col divide-y divide-gray-300 gap-2">
                {/* HEADER */}
                <div className="flex justify-between">
                    <div className="text-2xl font-bold flex-initial w-56 tabletOrDesktop:w-[40rem] ">
                        Today
                    </div>
                    <div className="flex gap-4 select-none">
                        {/* VIEW */}
                        <button
                            type="button"
                            className="text-md text-neutral-500 hover:text-neutral-700 focus:text-neutral-700 disabled:text-black/30 dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 [&.active]:text-black/90 dark:[&.active]:text-neutral-400"
                            // data-te-toggle="modal"
                            // data-te-target="#addtaskmodal"
                            // data-te-ripple-init
                            // data-te-ripple-color="light"
                        >
                            <div className="flex gap-2">
                                <span className="[&>svg]:w-5">
                                    <AdjustmentsHorizontalIcon />
                                </span>
                                View
                            </div>
                        </button>

                        {/* SETTING */}
                        <button
                            type="button"
                            className="text-md text-neutral-500 hover:text-neutral-700 focus:text-neutral-700 disabled:text-black/30 dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 [&.active]:text-black/90 dark:[&.active]:text-neutral-400"
                            // data-te-toggle="modal"
                            // data-te-target="#addtaskmodal"
                            // data-te-ripple-init
                            // data-te-ripple-color="light"
                        >
                            <span className="[&>svg]:w-5">
                                <EllipsisHorizontalIcon />
                            </span>
                        </button>
                    </div>
                </div>

                {/* TASKS */}
                {/* {tasks.map((task) => {
                    return (
                        task.isCompleted && (
                            <Task
                                key={task.id}
                                id={task.id}
                                name={task.name}
                                section_id={task.section_id}
                                due_Date={task.due_Date}
                                description={task.description}
                                isCompleted={task.isCompleted}
                            />
                        )
                    );
                })} */}
            </div>
        </div>
    );
};

export default TodayLayout;
