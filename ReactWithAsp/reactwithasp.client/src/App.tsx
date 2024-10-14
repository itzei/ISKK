import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Home from "./pages/HomePage/Home";
import { Layout } from "./pages/Layout";
import Students from "./pages/StudentsPage/Students";
import Lecturers from "./pages/LecturerPage/Lecturers";
import Programs from "./pages/ProgramPage/Programs";
import Groups from "./pages/GroupPage/Groups";
import Subjects from "./pages/SubjectPage/Subjects";

export default function App() {
    const router = createBrowserRouter([
        {
            path: "/",
            Component: Layout,
            children: [
                {
                    index: true,
                    Component: Home
                },
                {
                    path: 'students',
                    Component: Students
                },
                {
                    path: 'programs',
                    Component: Programs
                },
                {
                    path: 'lecturers',
                    Component: Lecturers
                },
                {
                    path: 'groups',
                    Component: Groups
                },
                {
                    path: 'subjects',
                    Component: Subjects
                },
            ]
        }
    ]);

    return <RouterProvider router={ router } />
}