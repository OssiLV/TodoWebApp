import { IProject, ISection } from "./Interfaces";

export interface IProjectLayoutComponent {
    listSections: ISection[];
    listProjects: IProject[];
}
