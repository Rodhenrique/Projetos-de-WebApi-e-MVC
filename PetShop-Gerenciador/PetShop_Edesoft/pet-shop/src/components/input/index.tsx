import React, { InputHTMLAttributes } from 'react';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
    label: string;
    name: string;
}

const Input: React.FunctionComponent<InputProps> = ({ label, name, ...rest }) => {
    return (
        <div>
            <div className="form-group row">
                <label className="col-md-4 col-form-label text-md-right" htmlFor={name}>{label}</label>
                <div className="col-md-6">
                    <input className="form-control" type="text" id={name}{...rest}></input>
                </div>
            </div>
        </div>
    );
}

export default Input