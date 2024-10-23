import { useForm } from "react-hook-form";
import { IUser } from "@/interfaces/IUser";
import { postApi } from "@/api";
import { formStyle } from "@/styles/formStyle";
import { Form, useNavigate } from "react-router-dom";
import { useState } from "react";
import { ErrorBlock } from "@/pages/components/ErrorBlock";

export default function SignUp() {
    const { register, handleSubmit, watch, formState: { errors } } = useForm<IUser & { confirm_password: string }>()
    const navigate = useNavigate();
    const [error, setError] = useState<string | undefined>()

    const storeUser = (data: IUser) => {
        if (error) setError(undefined)
        postApi('/Authentication/signup', data).then(i => {
            if (i?.error) {
                setError(i.error)
                return
            }
            navigate('/')
        })
    }
    return (
        <form onSubmit={handleSubmit(storeUser)} className='flex flex-col gap-3 max-w-xs'>
            {error ? <div className='text-red-800'>{error}</div> : null}
            <div>
                <label htmlFor="userName" className={formStyle.label}>Username</label>
                <input id="userName" className={formStyle.input} {...register("userName", {
                    required: "Username is required", maxLength: {
                        value: 20,
                        message: 'Username cannot exceed 20 characters'
                    }
                })} />
                <ErrorBlock errors={errors} name="userName"/>
            </div>
            <div>
                <label htmlFor="email" className={formStyle.label}>Email</label>
                <input id="email" className={formStyle.input} type="email" {...register("email", { required: "Email is required" })} />
                <ErrorBlock errors={ errors } name="email"/>
            </div>
            <div>
                <label htmlFor="password" className={formStyle.label}>Password</label>
                <input id="password" type="password" className={formStyle.input} {...register("password", {
                    required: "Password is required",
                    minLength: { value: 5, message: "Password must be atleast 5 characters long." },
                    maxLength: {value: 9, message: "Password cannot exceed 9 characters"}
                })} />
                <ErrorBlock errors={errors} name="password"/>
            </div>
            <div>
                <label htmlFor="confirm_password" className={formStyle.label}>Confirm password</label>
                <input id = "confirm_password" type = "password" className = { formStyle.input } {
                    ...register("confirm_password",{
                    required: "Confrim the password is required",
                    validate: (val: string) => {
                        if (watch('password') != val) {
                            return "Your passwords do not match";
                        }
                    },
                })} />
                <ErrorBlock errors={errors} name="confirm_password"/>
            </div>
            <button className={formStyle.button} type="submit">Create</button>
        </form>
    )
}
