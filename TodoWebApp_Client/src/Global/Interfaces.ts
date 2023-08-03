// Interface Component
export interface IListColors {
    listColors: IColor[];
}
export interface IListProject {
    listProjects: IProject[];
}

export interface IUser {
    id: string;
    email: string;
    emailConfirmed: boolean;
    userName: string;
}
export interface IProject {
    id: number;
    name: string;
    isFavorite: boolean;
    isDeleted: boolean;
    color: {
        id: number;
        tailwindBgHexCode: string;
        name: string;
    };
}
export interface IProject_FullData {
    id: number;
    name: string;
    isFavorite: boolean;
    isDeleted: boolean;
    color: {
        id: number;
        tailwindBgHexCode: string;
        name: string;
    };
    sections: ISection[];
}
export interface ITask {
    id: number;
    name: string;
    priority: string;
    due_Date: string;
    description: string;
    isCompleted: boolean;
    section_id: number;
}

export interface ISection {
    id: number;
    name: string;
    project_id: number;
}

export interface IColor {
    id: number;
    tailwindBgHexCode: string;
    name: string;
}

export interface IUser {
    id: string;
    userName: string;
    email: string;
    emailConfirmed: boolean;
}

export interface IPriority {
    name: "P1" | "P2" | "P3" | "P4";
}

export interface IDueDate {
    type: "" | "OPTIONS" | "CALENDAR";
    fullDateTime: string;
}

export interface RootState {
    rootUserReducer: IUser;
    rootProjectReducer: IProject;
    rootPriorityReducer: IPriority;
    rootDueDateReducer: IDueDate;
    rootSectionReducer: ISection;
    rootProjectSoftDeleteReducer: IProjectSoftDelete;
    rootDataTransferReducer: IDataTransfer;
    rootTaskTodoReducer: ITask;
    rootTaskTodoHandleComplete: ITaskTodoHandleComplete;
}
export interface IProjectSoftDelete {
    id: number;
    isDeleted: boolean;
}

export interface ITaskTodoHandleComplete {
    id: number;
    isCompleted: boolean;
}

export interface IDataTransfer {
    id?: number;
    name?: string;
    categories: string;
    tailwindBgHexCode: string;
}
