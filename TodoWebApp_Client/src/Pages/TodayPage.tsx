import { Fragment, useEffect, useState } from "react";
import {
    NavbarComponent,
    SidenavComponent,
    ToastMessageComponent,
} from "../Components";
import { TodayLayout } from "../Layouts";
import axios from "axios";

import { useSelector } from "react-redux";

import { RootStates, IProject, IProject_FullData, ISection } from "../Global";
const TodayPage = () => {
    const _user = useSelector((state: RootStates) => state.rootUserReducer);
    const _newProject = useSelector(
        (state: RootStates) => state.rootProjectReducer
    );
    const _newSection = useSelector(
        (state: RootStates) => state.rootSectionReducer
    );
    const _projectSoftDelete = useSelector(
        (state: RootStates) => state.rootProjectSoftDeleteReducer
    );

    const [fullDataProject, setFullDataProject] = useState<IProject_FullData[]>(
        []
    );
    const [listSections, setListSections] = useState<ISection[]>([]);
    const [listProjects, setListProjects] = useState<IProject[]>([]);

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
            const projects: IProject[] = fullDataProject?.map(
                (project: IProject) => ({
                    id: project.id,
                    name: project.name,
                    isFavorite: project.isFavorite,
                    isDeleted: project.isDeleted,
                    color: project.color,
                })
            );
            const uniqueArray = projects?.reduce(
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
            const sections: ISection[] = fullDataProject?.flatMap(
                (project: IProject_FullData) =>
                    project.sections.map((section: ISection) => ({
                        id: section.id,
                        name: section.name,
                        project_id: section.project_id,
                    }))
            );
            const uniqueArray = sections?.reduce(
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

    useEffect(() => {
        setListProjects((prevState) =>
            prevState.reduce((acc: IProject[], current: IProject) => {
                if (current.id === _projectSoftDelete.id) {
                    // Return a new object with the updated isDeleted property
                    return [
                        ...acc,
                        { ...current, isDeleted: _projectSoftDelete.isDeleted },
                    ];
                }
                // Return the original object
                return [...acc, current];
            }, [])
        );
    }, [_projectSoftDelete]);

    return (
        <Fragment>
            <NavbarComponent />
            <SidenavComponent listProjects={listProjects} />
            <TodayLayout />
            {_projectSoftDelete.isDeleted ? (
                <ToastMessageComponent
                    title="Warning"
                    content="Project is deleted"
                />
            ) : (
                ""
            )}
        </Fragment>
    );
};

export default TodayPage;
