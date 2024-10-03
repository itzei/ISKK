import { useEffect, useState } from "react"
import { IStudent } from "../../interfaces/IStudent";
import { getApi, postApi, putApi } from "../../api";
import { Modal } from "../components/Modal";
import { StudentForm } from "./components/StudentForm";

export default function Students() {
    const [students, setStudents] = useState<IStudent[]>([])
    const [visibleModal, setVisibleModal] = useState<boolean>(false)
    const [editStudent, setEditStudent] = useState<IStudent | undefined>()

    const getStudents = () => getApi<IStudent[]>('Student').then(s => s && setStudents(s))

    const storeStudent = (student: IStudent) => {
        setVisibleModal(false)
        if (student.id) {
            putApi(`Student/${student.id}`, student).then(r => getStudents()).then(i => i)
        }
        else {
            postApi(`Student`, student).then(r => getStudents()).then(i => i)
        }
    }

    const editHandler = (student: IStudent) => {
        setEditStudent(student)
        setVisibleModal(true)
    }

    const addStudent = () => {
        setEditStudent(undefined)
        setVisibleModal(true)
    }

    useEffect(() => {
        getStudents().then(i => i)
    }, []);

    return <div>
        {
            visibleModal ? <Modal visibleModal={visibleModal} setVisibleModal={setVisibleModal} title='Studentu forma'>
                <StudentForm storeStudent={storeStudent} student={editStudent}/>
            </Modal> :null
        }
        <div className="text-3xl">Students</div>
        <button type="button" onClick={addStudent}>Add new Student</button>
        <div>{
            students.map(student => <div key={student.id}><button type="button" onClick={() => editHandler(student)}>{student.firstName} {student.lastName}</button>{" " + student.email}</div>)}</div>
    </div>
}