import React from 'react';
import './button.css';

// const LinkBehavior = React.forwardRef((props, ref) => (
//     <RouterLink ref={ref} to="/getting-started/installation/" {...props} />
//   ));
  
//   export default function ButtonRouter() {
//     return (
//       <Router>
//         <div>
//         <button type="button" onClick={console.log("Clique")}>{props.name}</button>
//           <Button color="primary" component={RouterLink} to="/">
            
//           </Button>
//           <br />
//           <Button color="primary" component={LinkBehavior}>
//             Without prop forwarding
//           </Button>
//         </div>
//       </Router>
//     );
//   }

const button = (props) => <button type="button" onClick={() => props.onClick()}>{props.name}</button>

export default button; 