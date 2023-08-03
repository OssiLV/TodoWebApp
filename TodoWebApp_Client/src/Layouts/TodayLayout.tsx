import { useEffect, useState } from "react";
import {
    AdjustmentsHorizontalIcon,
    EllipsisHorizontalIcon,
} from "@heroicons/react/24/solid";
import { ITask } from "../Global/Interfaces";
import { Task } from "../Components";

const TodayLayout = () => {
    const [tasks, setTasks] = useState<Array<ITask>>([]);

    useEffect(() => {
        // const _tasks: ITask[] = [
        //     {
        //         id: 0,
        //         name: "name",
        //         description: "",
        //         due_Date: "23 Jul",
        //         isCompleted: false,
        //         section_id: 0,
        //     },
        //     {
        //         id: 2,
        //         name: "name2",
        //         description: "name2",
        //         due_Date: "23 Jul",
        //         isCompleted: false,
        //         section_id: 1,
        //     },
        //     {
        //         id: 3,
        //         name: "name3",
        //         description: "name3",
        //         due_Date: "23 Jul",
        //         isCompleted: false,
        //         section_id: 2,
        //     },
        // ];
        // setTasks(_tasks);
    }, []);

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
