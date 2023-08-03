import { Bars3Icon, BellIcon, PlusIcon } from "@heroicons/react/24/solid";
import { Fragment } from "react";
import ModalAddTaskComponent from "./Modals/ModalAddTaskComponent";
import ModalDueDateComponent from "./Modals/ModalDueDateComponent";
import ModalPriorityComponent from "./Modals/ModalPriorityComponent";

const NavbarComponent = () => {
    return (
        <Fragment>
            <ModalAddTaskComponent />
            <ModalDueDateComponent />
            <ModalPriorityComponent />
            <nav
                className="fixed flex-no-wrap h-12 z-50 flex w-full items-center justify-between bg-neutral-100 py-2 shadow-md shadow-black/5 dark:bg-neutral-600 dark:shadow-black/10 lg:flex-wrap lg:justify-start lg:py-4"
                data-te-navbar-ref
            >
                <div className="flex w-full flex-wrap items-center justify-between px-3 ">
                    {/* NAV-LEFT-SIDE */}
                    <button
                        type="button"
                        className="block border-0 bg-transparent px-2 text-neutral-500 hover:no-underline hover:shadow-none focus:no-underline focus:shadow-none focus:outline-none focus:ring-0 dark:text-neutral-200 lg:hidden rounded-lg transition duration-500 ease-linear active:bg-slate-300 active:text-inherit active:outline-none data-[te-sidenav-state-active]:text-inherit data-[te-sidenav-state-focus]:outline-none dark:active:bg-white/10"
                        data-te-sidenav-toggle-ref
                        data-te-target="#sidebar"
                        aria-controls="#sidebar"
                    >
                        <span className="[&>svg]:w-7">
                            <Bars3Icon />
                        </span>
                    </button>

                    {/* NAV-RIGHT-SIDE */}
                    <div className="relative flex items-center">
                        {/* ADD-TASK */}
                        <button
                            type="button"
                            className="mr-4 text-neutral-500 hover:text-neutral-700 focus:text-neutral-700 disabled:text-black/30 dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 [&.active]:text-black/90 dark:[&.active]:text-neutral-400"
                            data-te-toggle="modal"
                            data-te-target="#addtaskmodal"
                            data-te-ripple-init
                            data-te-ripple-color="light"
                        >
                            <span className="[&>svg]:w-5">
                                <PlusIcon />
                            </span>
                        </button>

                        {/* BELL */}
                        <div className="relative">
                            <div className="hidden-arrow mr-4 flex items-center text-neutral-500 hover:text-neutral-700 focus:text-neutral-700 disabled:text-black/30 dark:text-neutral-200 dark:hover:text-neutral-300 dark:focus:text-neutral-300 [&.active]:text-black/90 dark:[&.active]:text-neutral-400">
                                <span className="[&>svg]:w-5">
                                    <BellIcon />
                                </span>

                                <span className="absolute -mt-2.5 ml-2 rounded-[0.37rem] bg-danger px-[0.45em] py-[0.2em] text-[0.6rem] leading-none text-white">
                                    1
                                </span>
                            </div>
                        </div>

                        {/* AVATAR */}
                        <div className="relative">
                            <div className="hidden-arrow flex items-center whitespace-nowrap transition duration-150 ease-in-out motion-reduce:transition-none">
                                <img
                                    src="https://tecdn.b-cdn.net/img/new/avatars/2.jpg"
                                    className="rounded-full h-[25px] w-[25px]"
                                    alt=""
                                    loading="lazy"
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </nav>
        </Fragment>
    );
};

export default NavbarComponent;
