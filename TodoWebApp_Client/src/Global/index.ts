import {
    IProjectUpdate,
    IProject,
    IProjectSoftDelete,
    IProject_FullData,
} from "./InterfaceProject";
import { IColor } from "./InterfaceColor";
import {
    IProjectLayoutComponent,
    ISidenavComponent,
    IModalTaskTodoComponent,
} from "./InterfaceComponents";
import { IDataTransfer } from "./InterfaceDataTransfer";
import { IDueDate } from "./InterfaceDueDate";
import { IPriority } from "./InterfacePriority";
import { RootStates } from "./InterfaceRootReducer";
import { ISection } from "./InterfaceSections";
import { ITaskTodo, ITaskTodoHandleComplete } from "./InterfaceTaskTodo";
import { IUser } from "./InterfaceUser";
import { formatDate, parseDate, isEmptyObject } from "./Actions";
import { IModal } from "./InterfaceModal";

export type {
    IProjectUpdate,
    IProject,
    IProjectSoftDelete,
    IProject_FullData,
    IColor,
    IProjectLayoutComponent,
    ISidenavComponent,
    IModalTaskTodoComponent,
    IDataTransfer,
    IDueDate,
    IPriority,
    RootStates,
    ISection,
    ITaskTodo,
    ITaskTodoHandleComplete,
    IUser,
    IModal,
};

export { parseDate, formatDate, isEmptyObject };
