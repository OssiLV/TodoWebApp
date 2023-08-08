import { IProject } from "./InterfaceProject";
import { ISection } from "./InterfaceSections";

export interface IProjectLayoutComponent {
    listSections: ISection[];
    listProjects: IProject[];
}

export interface IModalTaskTodoComponent {
    listSections: ISection[];
    listProjects: IProject[];
}

export interface ISidenavComponent {
    listProjects: IProject[];
}
