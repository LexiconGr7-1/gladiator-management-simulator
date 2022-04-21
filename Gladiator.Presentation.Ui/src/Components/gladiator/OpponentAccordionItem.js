import { useState } from "react";

const OpponentAccordionItem = (props) => {
    const { gladiator, selectedGladiator } = props;

    const [battle, setBattle] = useState("");

    const handleSelected = (name) => {
        setBattle(
            `Runs battle between ${selectedGladiator} and Gladiator ${name}!`
        );
    };

    return (
        <div className="accordion-item">
            <h2
                className="accordion-header"
                id={"flush-heading-" + gladiator.gladiator.id}
            >
                <button
                    className="accordion-button collapsed"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target={`#${"collapse-" + gladiator.gladiator.id}`}
                    aria-expanded="false"
                    aria-controls={"collapse-" + gladiator.gladiator.id}
                    onClick={() => {
                        handleSelected(gladiator.gladiator.name);
                    }}
                >
                    {gladiator.gladiator.name}
                </button>
            </h2>
            <div
                id={"collapse-" + gladiator.gladiator.id}
                className="accordion-collapse collapse"
                aria-labelledby={"flush-heading-" + gladiator.gladiator.id}
                data-bs-parent="#accordionFlushExample"
            >
                <div className="accordion-body">
                    <ul>
                        <li>Health: {gladiator.gladiator.health}</li>
                        <li>Strength: {gladiator.gladiator.strength}</li>
                    </ul>
                    {battle}
                </div>
            </div>
        </div>
    );
};

export default OpponentAccordionItem;
