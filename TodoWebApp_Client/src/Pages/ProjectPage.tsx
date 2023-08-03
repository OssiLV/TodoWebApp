import { Fragment, useEffect, useState } from "react";
import {
    ModalCategoryComponent,
    NavbarComponent,
    SidenavComponent,
} from "../Components";
import { ProjectLayout } from "../Layouts";
import axios from "axios";
import { useSelector } from "react-redux";
import {
    IProject,
    IProject_FullData,
    ISection,
    RootState,
} from "../Global/Interfaces";
import { useParams } from "react-router-dom";

const ProjectPage = () => {
    const { projectId } = useParams();
    let projectIdNumber: number | undefined;

    if (projectId) {
        try {
            projectIdNumber = parseInt(projectId);
        } catch (error) {
            console.log(error);
        }
    }
    const _user = useSelector((state: RootState) => state.rootUserReducer);
    const _newProject = useSelector(
        (state: RootState) => state.rootProjectReducer
    );
    const _newSection = useSelector(
        (state: RootState) => state.rootSectionReducer
    );
    // const [project, setProject] = useState<IProject>({
    //     id: 0,
    //     name: "",
    //     color: { id: 0, name: "", tailwindBgHexCode: "" },
    //     isDeleted: false,
    //     isFavorite: false,
    // });
    const [fullDataProject, setFullDataProject] = useState<IProject_FullData[]>(
        []
    );
    const [listSections, setListSections] = useState<ISection[]>([]);
    const [listProjects, setListProjects] = useState<IProject[]>([]);
    // const projectById = listProjects.find(
    //     (project) => project.id === projectIdNumber
    // );
    // let hehe: IProject = {
    //     id: 0,
    //     name: "",
    //     color: {
    //         id: 0,
    //         name: "",
    //         tailwindBgHexCode: "",
    //     },
    //     isDeleted: false,
    //     isFavorite: false,
    // };

    // if (projectById !== undefined) {
    //     hehe = projectById;
    // }

    useEffect(() => {
        axios({
            method: "GET",
            url: `/Project/fulldata/${_user.id}`,
        })
            .then((res) => {
                // console.log(res.data.objectData);

                setFullDataProject(res.data.objectData);
            })
            .catch((error) => {
                console.error("Cannot get full data: " + error);
            });
    }, [_user.id]);

    useEffect(() => {
        setListProjects((prevState) => {
            const projects: IProject[] = fullDataProject.map(
                (project: IProject) => ({
                    id: project.id,
                    name: project.name,
                    isFavorite: project.isFavorite,
                    isDeleted: project.isDeleted,
                    color: project.color,
                })
            );
            const uniqueArray = projects.reduce(
                (acc: IProject[], current: IProject) => {
                    if (!acc.find((element) => element.id === current.id)) {
                        acc.push(current);
                    }
                    return acc;
                },
                []
            );

            return prevState.concat(uniqueArray);
        });

        setListSections((prevState) => {
            const sections: ISection[] = fullDataProject.flatMap(
                (project: IProject_FullData) =>
                    project.sections.map((section: ISection) => ({
                        id: section.id,
                        name: section.name,
                        project_id: section.project_id,
                    }))
            );
            const uniqueArray = sections.reduce(
                (acc: ISection[], current: ISection) => {
                    if (!acc.find((element) => element.id === current.id)) {
                        acc.push(current);
                    }
                    return acc;
                },
                []
            );

            return prevState.concat(uniqueArray);
        });
    }, [fullDataProject]);

    useEffect(() => {
        if (_newProject !== null) {
            setListProjects((prevState) => {
                if (prevState !== null) {
                    return prevState.concat(_newProject);
                } else {
                    return [_newProject];
                }
            });
        }
    }, [_newProject]);

    useEffect(() => {
        if (_newSection !== null) {
            setListSections((prevState) => {
                if (prevState !== null) {
                    return prevState.concat(_newSection);
                } else {
                    return [_newSection];
                }
            });
        }
    }, [_newSection]);

    return (
        <Fragment>
            <NavbarComponent />
            <SidenavComponent listProjects={listProjects} />
            <ProjectLayout
                listSections={listSections}
                listProjects={listProjects}
            />
            <ModalCategoryComponent
                listProjects={listProjects}
                listSections={listSections}
            />
        </Fragment>
    );
};

export default ProjectPage;
