import OpponentAccordionItem from "./OpponentAccordionItem";

const OpponentAccordion = (props) => {
    const gladiators = props.gladiators;
    const selectedGladiator = props.selectedGladiator;

    return (
        <div className="accordion accordion-flush" id="accordionFlushExample">
            {gladiators &&
                gladiators.map((gladiator) => (
                    <OpponentAccordionItem
                        key={gladiator.gladiator.id}
                        gladiator={gladiator}
                        selectedGladiator={selectedGladiator}
                    />
                ))}
        </div>
    );
};

export default OpponentAccordion;
