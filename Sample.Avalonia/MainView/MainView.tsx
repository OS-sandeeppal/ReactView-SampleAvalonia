import * as React from "react";
import "./MainView.scss"; // import a stylesheet

// component properties ... the interface name must start with I prefix and end with Properties suffix
export interface IMainViewProperties {
    mouseOver(clientX: number, clientY: number): void;
    mouseLeave(): void;
}

// component methods that can be called on .NET  ... the interface name must start with I prefix and end with Behaviors suffix
export interface IMainViewBehaviors {
}

export default class MainView extends React.Component<IMainViewProperties> implements IMainViewBehaviors {
    constructor(props: IMainViewProperties) {
        super(props);
    }
    
    private onMouseOverHandler = (event: React.MouseEvent) => {
        this.props.mouseOver(event.clientX, event.clientY);
    }

    private onMouseLeaveHandler = () => {
        this.props.mouseLeave();
    }

    public render(): JSX.Element {
        return (
            <div className="wrapper">
                <div className="title">Sample</div>
                <input onMouseOver={(event) => this.onMouseOverHandler(event)} onMouseLeave={this.onMouseLeaveHandler} />
            </div>
        );
    }
}