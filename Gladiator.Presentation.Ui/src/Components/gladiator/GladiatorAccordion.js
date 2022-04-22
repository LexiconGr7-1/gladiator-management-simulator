import GladiatorAccordionItem from "./GladiatorAccordionItem";

const GladiatorAccordion = (props) => {
    const gladiators = props.gladiators;
    const setSelected = props.setSelected;
    return (
        <div className="accordion accordion-flush" id="accordionFlushExample">
            {gladiators &&
                gladiators.map((gladiator) => (
                    <GladiatorAccordionItem
                        key={gladiator.gladiator.id}
                        setSelected={setSelected}
                        gladiator={gladiator}
                    />
                ))}
        </div>
    );
};

export default GladiatorAccordion;
