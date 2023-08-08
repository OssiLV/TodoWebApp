import { PlusIcon } from "@heroicons/react/24/outline";
import { useEffect, useState } from "react";
import { Modal, Ripple, initTE } from "tw-elements";
import { useDispatch, useSelector } from "react-redux";
import { ITaskTodo, RootStates } from "../../Global";
import { FlagIcon as OFlagIcon } from "@heroicons/react/24/outline";
import { FlagIcon as SFlagIcon } from "@heroicons/react/24/solid";
import clsx from "clsx";
import ShowDueDateComponent from "../ShowDueDateComponent";
import axios from "axios";
import { formatDate } from "../../Global";
import { setTaskTodo } from "../../States/TaskTodoReducer";
import { setDueDate } from "../../States/DueDateReducer";
const ModalAddTaskComponent = () => {
    useEffect(() => {
        initTE({ Modal, Ripple });
    }, []);
    const dispatch = useDispatch();
    const _priority = useSelector(
        (state: RootStates) => state.rootPriorityReducer
    );
    const _dataTransfer = useSelector(
        (state: RootStates) => state.rootDataTransferReducer
    );
    let _projectName = _dataTransfer.categories.split("$_*_/_*_$")[0];
    let _sectionName = _dataTransfer.categories?.split("$_*_/_*_$")[1];

    const [dateTime, setDateTime] = useState("");
    const [taskName, setTaskName] = useState("");
    const [description, setDescription] = useState("");
    const [checkValue, setCheckValue] = useState(true);

    const handleChangeValueTaskName = (
        event: React.ChangeEvent<HTMLInputElement>
    ) => {
        setTaskName(event.target.value);
    };
    const handleChangeValueDescription = (
        event: React.ChangeEvent<HTMLInputElement>
    ) => {
        setDescription(event.target.value);
    };

    const handleAddTask = () => {
        dispatch(
            setDueDate({
                type: "",
                fullDateTime:
                    "Mon Jul 1 0000 00:00:00 GMT+0700 (Indochina Time)",
            })
        );
        axios({
            method: "POST",
            url: "/TaskTodo",
            data: {
                name: taskName,
                description: description,
                priority: _priority.name,
                isCompleted: false,
                due_Date: dateTime,
                createdAt: formatDate(new Date()),
                section_id: _dataTransfer.id,
                sectionName: _dataTransfer.name,
            },
        })
            .then((res) => {
                const newTaskTodo: ITaskTodo = res.data.objectData;

                dispatch(
                    setTaskTodo({
                        id: newTaskTodo.id,
                        name: newTaskTodo.name,
                        description: newTaskTodo.description,
                        priority: newTaskTodo.priority,
                        due_Date: newTaskTodo.due_Date,
                        isCompleted: newTaskTodo.isCompleted,
                        section_id: newTaskTodo.section_id,
                    })
                );
            })
            .catch((error) => {
                console.error("Cannot Create Task: ", error);
            });
    };
    const handleCancel = () => {
        dispatch(
            setDueDate({
                type: "",
                fullDateTime:
                    "Mon Jul 1 0000 00:00:00 GMT+0700 (Indochina Time)",
            })
        );
    };

    useEffect(() => {
        if (
            taskName.length < 0 ||
            taskName === "" ||
            dateTime === "07/01/2000 12:00:00 AM" ||
            (_dataTransfer.id === 0 && _dataTransfer.name === "")
        ) {
            setCheckValue(true);
        } else {
            setCheckValue(false);
        }
    }, [taskName, dateTime, _dataTransfer]);

    return (
        <div
            data-te-modal-init
            className="fixed  left-0 bottom-[10rem] z-[1055] hidden h-full w-full overflow-y-auto overflow-x-hidden outline-none"
            id="addtaskmodal"
            aria-labelledby="addtaskmodal"
            aria-modal="true"
            data-te-backdrop="static"
            data-te-keyboard="false"
            role="dialog"
        >
            <div
                data-te-modal-dialog-ref
                className="pointer-events-none relative flex min-h-[calc(100%-1rem)] w-auto translate-y-[-50px] items-center opacity-0 transition-all duration-300 ease-in-out min-[576px]:mx-auto min-[576px]:mt-7 min-[576px]:min-h-[calc(100%-3.5rem)] min-[576px]:max-w-[500px]"
            >
                <div className="pointer-events-auto relative flex w-full flex-col rounded-md border-none bg-white bg-clip-padding text-current shadow-lg outline-none dark:bg-neutral-600">
                    {/* MODAL-BODY */}
                    <div className="relative p-4 ">
                        {/* TASK-NAME */}
                        <div className="relative mb-3">
                            <input
                                className="text-xl min-h-[auto] w-full rounded border-0 bg-transparent px-3 py-[0.32rem] leading-[1.6] outline-none"
                                type="text"
                                placeholder="Task Name"
                                value={taskName}
                                onChange={handleChangeValueTaskName}
                                aria-autocomplete="none"
                            />
                        </div>

                        {/* DESCRIPTION */}
                        <div className="relative mb-3">
                            <input
                                className="text-sm min-h-[auto] w-full rounded border-0 bg-transparent px-3 py-[0.32rem] leading-[1.6] outline-none "
                                type="text"
                                placeholder="Description"
                                value={description}
                                onChange={handleChangeValueDescription}
                                aria-autocomplete="none"
                            />
                        </div>

                        {/* OPTIONS */}
                        <div className="my-4 flex items-center gap-3">
                            {/* DUE DATE */}
                            <div
                                className="flex items-center w-26 text-sm border border-opacity-50 rounded-lg p-[6px] hover:bg-gray-300 hover:cursor-pointer"
                                data-te-toggle="modal"
                                data-te-target="#calendaroption"
                                data-te-ripple-init
                                data-te-ripple-color="light"
                            >
                                <ShowDueDateComponent
                                    setDateTime={setDateTime}
                                />
                            </div>

                            {/* RPIORITY */}
                            <div
                                className="flex items-center w-26 text-sm border border-opacity-50 rounded-lg p-[6px]  hover:bg-gray-300 hover:cursor-pointer"
                                data-te-toggle="modal"
                                data-te-target="#priorityoption"
                                data-te-ripple-init
                                data-te-ripple-color="light"
                            >
                                {_priority.name === "P4" ? (
                                    <div className="flex items-center opacity-50">
                                        <span>
                                            <OFlagIcon
                                                className={clsx(`w-4 h-4 `)}
                                            />
                                        </span>
                                        <p className="ml-2 ">Priority</p>
                                    </div>
                                ) : (
                                    <div className="flex items-center">
                                        <span>
                                            <SFlagIcon
                                                className={clsx(`w-4 h-4 `, {
                                                    "text-red-600":
                                                        _priority.name === "P1",
                                                    "text-orange-500":
                                                        _priority.name === "P2",
                                                    "text-primary":
                                                        _priority.name === "P3",
                                                })}
                                            />
                                        </span>
                                        <p className="ml-2 font-thin">
                                            {_priority.name}
                                        </p>
                                    </div>
                                )}
                            </div>
                        </div>

                        {/* MODAL-FOOTER */}
                        {/* CATEGORY */}
                        <div className="flex items-center justify-between w-full">
                            <button
                                type="button"
                                className=" text-primary hover:text-neutral-700 focus:text-neutral-700 disabled:text-black/30 dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 [&.active]:text-black/90 dark:[&.active]:text-neutral-400"
                                data-te-toggle="modal"
                                data-te-target="#modalCategoryComponent"
                                data-te-ripple-init
                                data-te-ripple-color="light"
                            >
                                {_dataTransfer?.categories !== "" ? (
                                    <div className="flex items-center">
                                        <span
                                            className={clsx(
                                                "mr-4 h-3 w-3 rounded-full",
                                                {
                                                    "bg-[#6d28d9]":
                                                        _dataTransfer?.tailwindBgHexCode ===
                                                        "bg-[#6d28d9]",
                                                    "bg-[#dbeafe]":
                                                        _dataTransfer?.tailwindBgHexCode ===
                                                        "bg-[#dbeafe]",
                                                    "bg-[#60a5fa]":
                                                        _dataTransfer?.tailwindBgHexCode ===
                                                        "bg-[#60a5fa]",
                                                    "bg-[#a3a3a3]":
                                                        _dataTransfer?.tailwindBgHexCode ===
                                                        "bg-[#a3a3a3]",
                                                    "bg-[#0d9488]":
                                                        _dataTransfer?.tailwindBgHexCode ===
                                                        "bg-[#0d9488]",
                                                }
                                            )}
                                        ></span>
                                        <div className="flex text-black">
                                            {_projectName.length >= 15
                                                ? _projectName.substring(
                                                      0,
                                                      10
                                                  ) + "..."
                                                : _projectName}

                                            {_sectionName ? (
                                                <p className="flex items-center">
                                                    <span className="mx-1">
                                                        /
                                                    </span>
                                                    <svg
                                                        xmlns="http://www.w3.org/2000/svg"
                                                        width="24"
                                                        height="24"
                                                        viewBox="0 0 24 24"
                                                    >
                                                        <path
                                                            fill="currentColor"
                                                            d="M19.5 20a.5.5 0 010 1h-15a.5.5 0 010-1h15zM18 6a2 2 0 012 2v8a2 2 0 01-2 2H6a2 2 0 01-2-2V8a2 2 0 012-2h12zm0 1H6a1 1 0 00-1 1v8a1 1 0 001 1h12a1 1 0 001-1V8a1 1 0 00-1-1zm-6 2a.5.5 0 01.5.5v2h2a.5.5 0 010 1h-2v2a.5.5 0 01-1 0v-2h-2a.5.5 0 010-1h2v-2A.5.5 0 0112 9zm7.5-6a.5.5 0 010 1h-15a.5.5 0 010-1h15z"
                                                        ></path>
                                                    </svg>
                                                    {_projectName.length >= 15
                                                        ? _sectionName.substring(
                                                              0,
                                                              10
                                                          ) + "..."
                                                        : _sectionName}
                                                </p>
                                            ) : (
                                                ""
                                            )}
                                        </div>
                                    </div>
                                ) : (
                                    <span className="">
                                        <PlusIcon className="w-5" />
                                    </span>
                                )}
                            </button>

                            <div className="flex items-center ">
                                <button
                                    type="button"
                                    className="inline-block rounded bg-primary-100 px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-primary-700 transition duration-150 ease-in-out hover:bg-primary-accent-100 focus:bg-primary-accent-100 focus:outline-none focus:ring-0 active:bg-primary-accent-200"
                                    data-te-modal-dismiss
                                    data-te-ripple-init
                                    data-te-ripple-color="light"
                                    onClick={handleCancel}
                                >
                                    Cancel
                                </button>
                                <button
                                    type="button"
                                    disabled={checkValue}
                                    onClick={handleAddTask}
                                    className="ml-1 inline-block rounded bg-primary px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#3b71ca] transition duration-150 ease-in-out hover:bg-primary-600 hover:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.3),0_4px_18px_0_rgba(59,113,202,0.2)] focus:bg-primary-600 focus:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.3),0_4px_18px_0_rgba(59,113,202,0.2)] focus:outline-none focus:ring-0 active:bg-primary-700 active:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.3),0_4px_18px_0_rgba(59,113,202,0.2)] dark:shadow-[0_4px_9px_-4px_rgba(59,113,202,0.5)] dark:hover:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.2),0_4px_18px_0_rgba(59,113,202,0.1)] dark:focus:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.2),0_4px_18px_0_rgba(59,113,202,0.1)] dark:active:shadow-[0_8px_9px_-4px_rgba(59,113,202,0.2),0_4px_18px_0_rgba(59,113,202,0.1)]"
                                    data-te-ripple-init
                                    data-te-modal-dismiss
                                    data-te-ripple-color="light"
                                >
                                    Add task
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ModalAddTaskComponent;
