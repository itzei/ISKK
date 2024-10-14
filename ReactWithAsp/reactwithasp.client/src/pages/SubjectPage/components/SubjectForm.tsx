﻿import { useForm } from "react-hook-form";
import { ISubject } from "../../../interfaces/ISubject";
import { useEffect, useState } from "react";
import { formStyle } from "../../../styles/formStyle";


type SubjectFormProps = { subject: ISubject | undefined; storeSubject: (data: ISubject) => void }

export function SubjectForm(props: SubjectFormProps) {
    const { subject, storeSubject } = props;
    const { register, handleSubmit, reset } = useForm<ISubject>({ defaultValues: subject });

    useEffect(() => {
        reset(subject);
    }, [subject, reset]);

    return (
        <form onSubmit={handleSubmit(storeSubject)} className='flex flex-col gap-3' >
            {subject?.id && <input type="hidden" {...register("id")} />}
            <div>
                <label htmlFor="studyProgram" className={formStyle.label}>Studijų programa</label>
                <input id="studyProgram" className={formStyle.input} {...register("studyProgram", { required: true, maxLength: 50 })} defaultValue={subject?.studyProgram || ''} />
            </div>
            <div>
                <label htmlFor="subjectTitle" className={formStyle.label}>Dalykų pavadinimai</label>
                <input id="subjectTitle" className={formStyle.input} {...register("subjectTitle", { required: true, maxLength: 5000 })} defaultValue={subject?.subjectTitle || ''} />
            </div>
            <button className={formStyle.button} type="submit">Išsaugoti</button>
        </form>
    )
}