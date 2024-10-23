const [selectedOption, setSelectedOption] = useState<string | null>(null);

const handleSelect = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedOption(event.target.value);
};
<div>
    <label htmlFor="dropdown" > Choose an option: </label>
        < select id = "dropdown" value = { selectedOption || ''} onChange = { handleSelect } >
            <option value="" disabled > Select an option </option>
                < option value = "option1" > Option 1 </option>
                    < option value = "option2" > Option 2 </option>
                        < option value = "option3" > Option 3 </option>
                            </select>
{ selectedOption && <p>You selected: { selectedOption } </p> }
</div>