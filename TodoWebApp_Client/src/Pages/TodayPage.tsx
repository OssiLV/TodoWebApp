import { Fragment, useEffect, useState } from "react";
import {
    NavbarComponent,
    SidenavComponent,
    ToastMessageComponent,
} from "../Components";
import { TodayLayout } from "../Layouts";
import axios from "axios";

import { useSelector } from "react-redux";

import { RootState, IProject } from "../Global/Interfaces";
const TodayPage = () => {
    const _user = useSelector((state: RootState) => state.rootUserReducer);
    const [listProjects, setListProjects] = useState<IProject[]>([]);
    const _newProject = useSelector(
        (state: RootState) => state.rootProjectReducer
    );
    const _projectSoftDelete = useSelector(
        (state: RootState) => state.rootProjectSoftDeleteReducer
    );

    useEffect(() => {
        axios({
            method: "Get",
            url: `/Project/${_user.id}`,
        })
            .then((res) => {
                setListProjects(res.data.objectData);
            })
            .catch((error) => {
                console.error("Cannot get all Project: " + error);
            });
    }, [_user.id]);

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
