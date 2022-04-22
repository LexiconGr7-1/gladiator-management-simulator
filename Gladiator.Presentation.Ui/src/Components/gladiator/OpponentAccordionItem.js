import { useState } from "react";

const OpponentAccordionItem = (props) => {
    const { gladiator, selectedGladiator } = props;

    const [battleHeader, setBattleHeader] = useState("");
    const [battleDamageGladiator, setBattleDamageGladiator] = useState("");
    const [battleDamageOpponent, setBattleDamageOppnent] = useState("");
    const [battleExperienceGladiator, setBattleExperienceGladiator] =
        useState("");
    const [battleExperienceOpponent, setBattleExperienceOpponent] =
        useState("");
    const [gearGladiator, setGearGladiator] = useState("");
    const [gearOpponent, setGearOpponent] = useState("");
    const [resultBattleHeader, setResultBattleHeader] = useState("");
    const [gladScore, setGladScore] = useState("");
    const [oppScore, setOppScore] = useState("");
    const [win, setWin] = useState("");

    const handleSelected = (name) => {
        let stat = Math.floor(Math.random() * 11);
        setBattleHeader(
            `Runs battle between Players's gladiator ${selectedGladiator} and Opponent's Gladiator ${name}...`
        );
        setBattleDamageGladiator(
            `Player's gladiator ${selectedGladiator} does ${stat}hp damage...`
        );
        setBattleDamageOppnent(
            `Opponent's gladiator ${name} does ${stat}hp damage...`
        );
        let expGlad = Math.floor(Math.random() * 11);
        setBattleExperienceGladiator(
            `Player's gladiator ${selectedGladiator} has ${expGlad}xp experience...`
        );
        let expOpp = Math.floor(Math.random() * 11);
        setBattleExperienceOpponent(
            `Opponent's gladiator ${name} has ${expOpp}xp experience...`
        );
        let gladGear = Math.floor(Math.random() * 100);
        setGearGladiator(
            `Player's gladiator ${selectedGladiator} utilizes ${gladGear}% gear...`
        );
        let oppGear = Math.floor(Math.random() * 100);
        setGearOpponent(
            `Player's gladiator ${name} utilizes ${oppGear}% gear...`
        );
        setResultBattleHeader(`Result of battle:`);

        let gScore = Math.floor(Math.random() * 100);
        setGladScore(`Opponent's gladiator ${name} score: ${gScore}`);

        let oScore = Math.floor(Math.random() * 100);
        setOppScore(`Opponent's gladiator ${name} score: ${oScore}`);

        if (gScore > oScore) {
            setWin(
                `Player has vicory and gains ${gScore}xp points and 10 gold for battle!`
            );
        } else {
            setWin(
                `Opponent has victory and gains ${oScore}xp points and 10 gold for battle!`
            );
        }
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
                    <p>{battleHeader}</p>
                    <p>_______________</p>
                    <p>{battleDamageGladiator}</p>
                    <p>{battleDamageOpponent}</p>
                    <p>{battleExperienceGladiator}</p>
                    <p>{battleExperienceOpponent}</p>
                    <p>{gearGladiator}</p>
                    <p>{gearOpponent}</p>
                    <p>{resultBattleHeader}</p>
                    <p>{gladScore}</p>
                    <p>{oppScore}</p>
                    <p>_______________</p>
                    <p>{win}</p>
                </div>
            </div>
        </div>
    );
};

export default OpponentAccordionItem;
