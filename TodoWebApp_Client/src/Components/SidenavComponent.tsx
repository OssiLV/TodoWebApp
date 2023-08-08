import {
    BriefcaseIcon,
    CalendarDaysIcon,
    CalendarIcon,
    HeartIcon,
} from "@heroicons/react/24/solid";
import { FC, Fragment, useEffect } from "react";
import { Sidenav, initTE } from "tw-elements";
import { useMediaQuery } from "react-responsive";
import ModalAddProjectComponent from "./Modals/ModalAddProjectComponent";

import { ISidenavComponent } from "../Global";
import clsx from "clsx";
import { Link, useNavigate } from "react-router-dom";

const SidenavComponent: FC<ISidenavComponent> = ({ listProjects }) => {
    useEffect(() => {
        initTE({ Sidenav });
    }, []);

    const navigate = useNavigate();
    const isMobile = useMediaQuery({ query: "(max-width: 420px)" });

    const handleClickProject = (projectId: number, projectName: string) => {
        navigate(`/app/project/${projectId}`);
    };

    return (
        <Fragment>
            <ModalAddProjectComponent />
            <nav
                id="sidebar"
                className="fixed mt-[3.1rem] left-0 top-0 z-10 h-screen w-60 -translate-x-full overflow-hidden bg-white shadow-[0_4px_12px_0_rgba(0,0,0,0.07),_0_2px_4px_rgba(0,0,0,0.05)] data-[te-sidenav-hidden='false']:translate-x-0 dark:bg-zinc-800 "
                data-te-sidenav-init
                data-te-sidenav-hidden="false"
                data-te-sidenav-mode={isMobile ? "over" : "side"}
                data-te-sidenav-content="#content"
            >
                <ul
                    className="relative m-0 list-none px-[0.2rem] select-none"
                    data-te-sidenav-menu-ref
                >
                    {/* TODAY */}
                    <li className="relative">
                        <Link
                            to="/app/today"
                            className="flex h-12 cursor-pointer items-center truncate rounded-[5px] px-6 py-4 text-[0.875rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                            data-te-sidenav-link-ref
                        >
                            <span className="mr-4 h-4 w-4 text-lime-500 dark:text-gray-300">
                                <CalendarIcon className="" />
                            </span>
                            <span>Today</span>
                        </Link>
                    </li>

                    {/* UPCOMMING */}
                    <li className="relative">
                        <Link
                            to="/app/upcomming"
                            className="flex h-12 cursor-pointer items-center truncate rounded-[5px] px-6 py-4 text-[0.875rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                            data-te-sidenav-link-ref
                        >
                            <span className="mr-4 h-4 w-4 text-purple-500 dark:text-gray-300">
                                <CalendarDaysIcon className="" />
                            </span>
                            <span>Upcomming</span>
                        </Link>
                    </li>

                    {/* FAVORITES */}
                    <li className="relative">
                        <div
                            className="flex h-12 cursor-pointer items-center truncate rounded-[5px] px-6 py-4 text-[0.875rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                            data-te-sidenav-link-ref
                        >
                            <span className="mr-4 [&>svg]:h-4 [&>svg]:w-4 text-red-600 dark:[&>svg]:text-gray-300">
                                <HeartIcon className="" />
                            </span>
                            <span>Favorites</span>
                            <span
                                className="absolute right-0 ml-auto mr-[0.8rem] transition-transform duration-300 ease-linear motion-reduce:transition-none text-primary dark:[&>svg]:text-gray-300"
                                data-te-sidenav-rotate-icon-ref
                            >
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 20 20"
                                    fill="currentColor"
                                    className="h-5 w-5"
                                >
                                    <path
                                        fillRule="evenodd"
                                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                        clipRule="evenodd"
                                    />
                                </svg>
                            </span>
                        </div>
                        <ul
                            className="!visible relative m-0 hidden list-none p-0 data-[te-collapse-show]:block "
                            data-te-sidenav-collapse-ref
                        >
                            {listProjects?.map(
                                (project) =>
                                    project.isFavorite &&
                                    !project.isDeleted &&
                                    project.id !== 0 && (
                                        <li
                                            key={project.id}
                                            onClick={() =>
                                                handleClickProject(
                                                    project.id,
                                                    project.name
                                                )
                                            }
                                            className="flex h-6 cursor-pointer items-center truncate rounded-[5px] py-4 pl-[2.8rem] pr-6 text-[0.78rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                                            data-te-sidenav-link-ref
                                        >
                                            <span
                                                className={clsx(
                                                    "mr-4 h-3 w-3 rounded-full",
                                                    {
                                                        "bg-[#6d28d9]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#6d28d9]",
                                                        "bg-[#dbeafe]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#dbeafe]",
                                                        "bg-[#60a5fa]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#60a5fa]",
                                                        "bg-[#a3a3a3]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#a3a3a3]",
                                                        "bg-[#0d9488]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#0d9488]",
                                                    }
                                                )}
                                            ></span>
                                            <div>
                                                {project.name.length >= 15
                                                    ? project.name.substring(
                                                          0,
                                                          15
                                                      ) + "...."
                                                    : project.name}
                                            </div>
                                        </li>
                                    )
                            )}
                        </ul>
                    </li>

                    {/* PROJECTS */}
                    <li className="relative">
                        <div
                            className="flex h-12 cursor-pointer items-center truncate rounded-[5px] px-6 py-4 text-[0.875rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                            data-te-sidenav-link-ref
                        >
                            <span className="mr-4 [&>svg]:h-4 [&>svg]:w-4 text-primary dark:[&>svg]:text-gray-300">
                                <BriefcaseIcon />
                            </span>
                            <span>Projects</span>
                            <span
                                className="absolute right-0 ml-auto mr-[0.8rem] transition-transform duration-300 ease-linear motion-reduce:transition-none text-primary dark:[&>svg]:text-gray-300"
                                data-te-sidenav-rotate-icon-ref
                            >
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    viewBox="0 0 20 20"
                                    fill="currentColor"
                                    className="h-5 w-5"
                                >
                                    <path
                                        fillRule="evenodd"
                                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                                        clipRule="evenodd"
                                    />
                                </svg>
                            </span>
                        </div>
                        <ul
                            className="show !visible relative m-0 hidden list-none p-0 data-[te-collapse-show]:block "
                            data-te-sidenav-collapse-ref
                        >
                            <li className="relative">
                                <button
                                    className="flex h-6 text-primary font-bold cursor-pointer items-center truncate rounded-[5px] py-4 pl-[3.4rem] pr-6 text-[0.78rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit hover:outline-none focus:bg-slate-50 focus:text-inherit focus:outline-none active:bg-slate-50 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none motion-reduce:transition-none dark:text-gray-300 dark:hover:bg-white/10 dark:focus:bg-white/10 dark:active:bg-white/10"
                                    data-te-sidenav-link-ref
                                    data-te-toggle="modal"
                                    data-te-target="#addprojectmodal"
                                    data-te-ripple-init
                                    data-te-ripple-color="light"
                                    type="button"
                                >
                                    - - - - - Add A Project - - - - -
                                </button>
                            </li>

                            {listProjects?.map(
                                (project) =>
                                    !project.isDeleted &&
                                    project.id !== 0 && (
                                        <li
                                            key={project.id}
                                            onClick={() =>
                                                handleClickProject(
                                                    project.id,
                                                    project.name
                                                )
                                            }
                                            className="flex h-6 cursor-pointer items-center truncate rounded-[5px] py-4 pl-[2.8rem] pr-6 text-[0.78rem] text-gray-600 outline-none transition duration-300 ease-linear hover:bg-slate-50 hover:text-inherit"
                                            data-te-sidenav-link-ref
                                        >
                                            <span
                                                className={clsx(
                                                    "mr-4 h-3 w-3 rounded-full",
                                                    {
                                                        "bg-[#6d28d9]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#6d28d9]",
                                                        "bg-[#dbeafe]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#dbeafe]",
                                                        "bg-[#60a5fa]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#60a5fa]",
                                                        "bg-[#a3a3a3]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#a3a3a3]",
                                                        "bg-[#0d9488]":
                                                            project.color
                                                                .tailwindBgHexCode ===
                                                            "bg-[#0d9488]",
                                                    }
                                                )}
                                            ></span>
                                            <div>
                                                {project.name.length >= 15
                                                    ? project.name.substring(
                                                          0,
                                                          15
                                                      ) + "...."
                                                    : project.name}
                                            </div>
                                        </li>
                                    )
                            )}
                        </ul>
                    </li>
                </ul>
            </nav>
        </Fragment>
    );
};

export default SidenavComponent;
